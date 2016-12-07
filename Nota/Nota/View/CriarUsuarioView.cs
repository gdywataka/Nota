using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS = Nota.WebService.Ws;
using Xamarin.Forms;
using Nota.Model;
using Nota.View;
namespace Nota.ViewModel


{
    class CriarUsuarioView : ContentPage
    {
        //Pagina view necessita implementar ContentPage
        public CriarUsuarioView()
        {
            var usuario = new Object();
            var usuarioViewModel = new UsuarioViewModel();
            //Dizendo que o vinculo é com a UsuarioViewModel
            this.BindingContext = usuarioViewModel;
            bool sucesso = false;
            //Criando label
            Label lbCriarUsuario = new Label
            {
                //Propiedades da label
                Text = "Criar Usuario",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button))
            };
            //Criando um campo de texto pequeno
            Entry entryEmail = new Entry
            {
                //Propiedades
                Placeholder = "Email",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Text,
                //Dizendo qual nome do vinculo sendo utilizado
                Text = "{Binding EmailUsuario}"

            };
            //Criando vinculo com a propiedade EmailUsuario 
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

            Button btnCriar = new Button
            {
                Text = "Criar",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Fill,

            };
            //Botão utilizando delegate
            btnCriar.Clicked +=  delegate
            {

                usuarioViewModel.criarUsuario() ;

                if (sucesso == true)
                {
                    //Mudar pagina
                   Navigation.PushAsync(new PrincipalView());
                }
                else
                {
                    //Disparar um modal de erro
                    DisplayAlert("Erro", "Algo deu errado", "Ok");
                }
            };
            //Como layout sera montado
            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    lbCriarUsuario,
                    entryEmail,
                    entryLogin,
                    entrySenha,
                    btnCriar

                },
                //Espaçamento da pagina
                HeightRequest = 1500,
                Padding = 20
            };

            //Criando uma view
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stackLayout
            };
            //Titulo
            this.Title = "Criar Conta";
            //View
            this.Content = scrollView;
        }
    }
}
