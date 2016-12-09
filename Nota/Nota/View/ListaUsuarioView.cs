using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Nota.ViewModel;
using Nota.Model;
using System.Collections.ObjectModel;
using System.Reflection.Emit;



namespace Nota.View
{
    class ListaUsuarioView: ContentPage
    {
        public ObservableCollection<Usuario> usuarios;
        public ListaUsuarioView()
        {
            var usuario = new UsuarioViewModel();
            this.BindingContext = usuario;
            usuarios = new ObservableCollection<Usuario>();
            ListView listaView = new ListView();
            listaView.RowHeight = 40;
            listaView.ItemTapped += OnTap;
            listaView.ItemTemplate = new DataTemplate(typeof(CelulaUsuario));

            listaView.ItemsSource = usuario.listaUsuarios();
            Content = listaView;
        }
        void OnTap(object sender, ItemTappedEventArgs e)
        {
            var list = (ListView)sender;
            var usuario = (list.SelectedItem as Usuario);
            DisplayAlert("Usuario", "Email: " + usuario.email + "\n" + "Login: " + usuario.login+"Senha: " + usuario.senha, "OK");
            list.SelectedItem = null;
        }

    }
}
