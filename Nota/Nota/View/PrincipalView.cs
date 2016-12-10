using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nota.View
{
    public class PrincipalView : ContentPage
    {

        public PrincipalView()
        {
            var texto = new Label
            {
                Text = "Ola Xamarin =)",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout stackLayout = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = { texto } 
            };

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stackLayout
            };

            this.Title = "Xamarin";
        
        }
    }
}
