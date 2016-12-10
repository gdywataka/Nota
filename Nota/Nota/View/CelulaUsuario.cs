using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection.Emit;
using Nota.Model;

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
            var horizontalLayout = new StackLayout() { BackgroundColor = Color.Blue};

            emailLabel.SetBinding(Label.TextProperty, new Binding("email"));
            loginLabel.SetBinding(Label.TextProperty, new Binding("login"));
            senhaLabel.SetBinding(Label.TextProperty, new Binding("senha"));

            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
            emailLabel.FontSize = 12;
            loginLabel.FontSize = 12;
            senhaLabel.FontSize = 12;

            emailLabel.TextColor = Color.Olive;
            loginLabel.TextColor = Color.Olive;
            senhaLabel.TextColor = Color.Olive;

            verticaLayout.Children.Add(emailLabel);
            verticaLayout.Children.Add(loginLabel);
            verticaLayout.Children.Add(senhaLabel);

            horizontalLayout.Children.Add(verticaLayout);

            View = horizontalLayout;

        }
    }
}
