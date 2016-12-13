using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Nota.ViewModel;

namespace Nota.View
{
    class AtualizarUsuarioView: ContentPage
    {
        public AtualizarUsuarioView(Object user)
        {
            var usuario = user;
            var usuarioViewModel = new UsuarioViewModel();
            this.BindingContext = usuarioViewModel;

            Label lbAtualizarUsuario = new Label
            {
                Text = "Atualize o Usuario",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

            Entry entryEmail = new Entry
            {
                Placeholder = "Email",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Text,
                Text = "{Binding EmailUsuario}"

            };
            entryEmail.SetBinding(Entry.TextProperty, new Binding("EmailUsuario"));

            Entry entryLogin = new Entry
            {
                Placeholder = "Login",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Text,
                Text = "{Binding LoginUsuario}"

            };
            entryLogin.SetBinding(Entry.TextProperty, new Binding("LoginUsuario"));

            Entry entrySenha = new Entry
            {
                Placeholder = "Senha",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Text,
                Text = "{Binding SenhaUsuario}",
                IsPassword = true

            };
            entrySenha.SetBinding(Entry.TextProperty, new Binding("SenhaUsuario"));

            Button btnAtualizar = new Button
            {
                Text = "Atualizar",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,

            };



            btnAtualizar.Clicked += async(sender,args)=>
            {
                if(usuarioViewModel.atualizarUsuario())
                {
                    await DisplayAlert("Atualizado", "Atualizado com sucesso", "Ok");
                    await Navigation.PushAsync(new TabPrincipal());
                }
                else
                {
                    await DisplayAlert("Error", "Algo deu errado", "Ok");
                }
            };
            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    lbAtualizarUsuario,
                    entryEmail,
                    entryLogin,
                    entrySenha,
                    btnAtualizar

                },
          
                HeightRequest = 1500,
                Padding = 20
            };

           
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stackLayout
            };

            this.Title = "Atualizar Usuario";
            this.Content = scrollView;

        }
    }
}
