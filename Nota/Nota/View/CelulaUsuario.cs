using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nota.View
{
    public class CelulaUsuario : ViewCell
    {
       public CelulaUsuario()
        {
            var emailLabel = new Label();
            var loginLabel = new Label();
            var senhaLabel = new Label();

            var verticaLayout = new StackLayout();
            var horizontalLayout = new StackLayout() { BackgroundColor = Color.White};

            emailLabel.SetBinding(Label.TextProperty, new Binding("EmailUsuario"));
            loginLabel.SetBinding(Label.TextProperty, new Binding("LoginUsuario"));
            senhaLabel.SetBinding(Label.TextProperty, new Binding("SenhaUsuario"));

            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
            emailLabel.FontSize = 16;
            loginLabel.FontSize = 16;
            senhaLabel.FontSize = 16;

            emailLabel.TextColor = Color.Lime;
            loginLabel.TextColor = Color.Lime;
            senhaLabel.TextColor = Color.Lime;

            verticaLayout.Children.Add(emailLabel);
            verticaLayout.Children.Add(loginLabel);
            verticaLayout.Children.Add(senhaLabel);
            horizontalLayout.Children.Add(verticaLayout);
            View = horizontalLayout;

        }
    }
}
