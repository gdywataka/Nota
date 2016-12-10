using Nota.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WS = Nota.WebService.Ws;
namespace Nota.View
{
    public class LoginView : ContentPage
    {
        public LoginView()
        {
            var usuarioViewModel = new UsuarioViewModel();
            this.BindingContext = usuarioViewModel;
           


            Label lbLogar = new Label
            {
                Text = "Logue-se",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };

            Entry entryLogin = new Entry
            {
                Placeholder = "Login",
                HorizontalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text,
                Text = "{Binding LoginUsuario}"

            };

            entryLogin.SetBinding(Entry.TextProperty, new Binding("LoginUsuario"));


            Entry entrySenha = new Entry
            {
                Placeholder = "Senha",
                HorizontalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text,
                IsPassword = true,
                Text = "{Binding SenhaUsuario}"


            };

            entrySenha.SetBinding(Entry.TextProperty, new Binding("SenhaUsuario"));

            Button btnLogar = new Button
            {
                Text = "Logar",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Fill,

            };

            Button btnCriar = new Button
            {
                Text = "Criar",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Fill,

            };

            btnLogar.Clicked += delegate
            {
                if(usuarioViewModel.verificarUsuario())
                {
                    Navigation.PushAsync(new TabPrincipal());
                }
                else
                {
                    DisplayAlert("Error", "Login ou Senha Incorretos", "Ok");
                }


            };

            btnCriar.Clicked += async(sender, e) =>
            {
              await Navigation.PushAsync(new CriarUsuarioView());

            };

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    lbLogar,
                    entryLogin,
                    entrySenha,
                    btnLogar,
                    btnCriar


                },
                HeightRequest = 1500,
                Padding = 20
            };

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stackLayout
            };

            this.Title = "Login";
            this.Content = scrollView;

        }
    }
}
