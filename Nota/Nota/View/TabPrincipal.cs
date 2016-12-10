using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Nota.View
{
    public class TabPrincipal :TabbedPage
    {
      public  TabPrincipal()
        {
            Children.Add(new PrincipalView()
            {
                Title="Principal"
            });
            Children.Add(new ListaUsuarioView()
            {
                Title = "Usuarios"
            });
            this.SelectedItem = Children[0];

        }
       
            
            
    }
}
