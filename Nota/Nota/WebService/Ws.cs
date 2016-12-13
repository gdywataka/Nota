using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nota.DTO;
using Nota.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Nota.WebService
{
    public static class Ws
    {
        public static readonly String WS_HOST = "http://10.0.3.2:9999/PowaNota/WS";
        public static readonly String LISTAR_USUARIOS = "/Usuario/recuperar";
        public static readonly String CRIAR_USUARIO = "/Usuario/criar";
        public static readonly String ATUALIZAR_USUARIO = "/Usuario/atualizar";

        public static async Task<Boolean> donwloadUsuarios(string login, string senha)
        {
            bool sucesso = false;

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(WS_HOST + LISTAR_USUARIOS);

                if (response.IsSuccessStatusCode)
                {
                    var jsonRecebido = await response.Content.ReadAsStringAsync();
                    GenericDTO dto = JsonConvert.DeserializeObject<GenericDTO>(jsonRecebido);
                    dto.payload = ((JArray)dto.payload).ToObject<List<Usuario>>();

                    foreach (Usuario user in (List<Usuario>)dto.payload)
                    {
                        if (user.login.Equals(login) && user.senha.Equals(senha))
                        {

                            sucesso = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Atenção", ex.Message, "Ok");
                return sucesso;
            }
            return sucesso;
        }

        public static async Task<Boolean> criarUsuario(Object usuario)
        {
            bool sucesso = false;
            try
            {
                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync
                (string.Concat(WS_HOST , CRIAR_USUARIO),content);

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
    }
}
