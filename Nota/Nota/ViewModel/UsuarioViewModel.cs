using Newtonsoft.Json;
using Nota.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WS = Nota.WebService.Ws;
using Nota.DTO;
using Newtonsoft.Json.Linq;

namespace Nota.ViewModel
{
    //Implementando o metodo de notificador de mudança de propiedade
    class UsuarioViewModel : INotifyPropertyChanged
    {
        public UsuarioViewModel()
        {
            this.usuario = new Usuario();
        }
        //Necessariamente cria-se  um evento  
        public event PropertyChangedEventHandler PropertyChanged;
        public bool sucesso = false;

        Usuario usuario;
        /* Generic utilizada para setar os valores em propiedades que estão sendo modificadas,
         Ref Storage = Pega o valor que a variavel ja possui
         Value = Valor que esta em transição 
         PropertyName com CalllerMemberName que diz o nome da propiedade ,tendo como efeito não errar o nome da propiedade referenciada.
         Sendo nula pois não precisa ser passada*/
        bool SetProperty<T>(ref T storage,T value,[CallerMemberName]string propertyName = null )
        {
            //Se o valor for o mesmo,significa que a propiedade não esta sendo modificada,assim retornando nulo
            if (Object.Equals(storage, value))
            return false;

            //Se for verdadeiro modificara o valor do storage pelo valor novo,e dara trigger no propertyChanged
            storage = value;
            //Passando o nome da variavel sendo modificada por parametro e executara propertyChanged
            OnPropertyChanged(propertyName);
            return true;
        }

        public string EmailUsuario
        {
            //Implementado metodo generico SetProperty na instancia usuario da classe
            set { SetProperty(ref usuario.email, value); }

            get { return usuario.email; }
        }

        public string LoginUsuario
        {
            //Implementado metodo generico SetProperty
            set { SetProperty(ref usuario.login, value); }

            get { return usuario.login; }
        }


        public string SenhaUsuario
        {
            set { SetProperty(ref usuario.senha, value); }
            get { return usuario.senha; }
        }

        public  bool   criarUsuario()
        {
            try
            {
                var json = JsonConvert.SerializeObject(this.usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync
                (string.Concat(WS.WS_HOST, WS.CRIAR_USUARIO), content).Result;

                if (response.IsSuccessStatusCode)
                {
                    sucesso = true;
                    return sucesso;
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Atenção", ex.Message, "Ok");
            }
            return sucesso;
        }

        public bool verificarUsuario()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.GetAsync(string.Concat(WS.WS_HOST, WS.LISTAR_USUARIOS)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonRecebido = response.Content.ReadAsStringAsync().Result;
                    GenericDTO dto = JsonConvert.DeserializeObject<GenericDTO>(jsonRecebido);
                    dto.payload = ((JArray)dto.payload).ToObject<List<Usuario>>();
                    foreach (Usuario user in (List<Usuario>)dto.payload)
                    {
                        if (user.login.Equals(usuario.login) && user.senha.Equals(usuario.senha))
                        {
                            sucesso = true;
                            return sucesso;
                        }
                    }
                 
                }
                sucesso = false;
                return sucesso;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
                
            }
        }





        //Necessita implmentar um metodo,pois possi porpertyChanged
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
