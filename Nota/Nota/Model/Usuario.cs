using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nota.Model
{
    //Usuario herdando de base model,sinalizando que é uma propiedade que será mudada.(PropertyChanged)
    public class Usuario : BaseModel
    {
        public int id;
        public string email;
        public string login;
        public string senha;

    }
}
