using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nota.Model
{
    public class BaseModel
    {
        //Quando se implementa propertyChanged,necessarimente  ele precisara de um metódo dizendo como as propiedades sera alterada.
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseModel()
        {

        }
        //Metodo(CallerMemberName referenciando o nome da propiedade(Para que nao ocorra erros de digitação,setando propertyname = null, para que não necessite de um nome passado)
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Handler = variavel para genciamento de eventos
            var handler = PropertyChanged;
            //Se occorrer alguma mudança na propiedade,sera ativado.
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

