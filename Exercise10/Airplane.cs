using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Airplane : Vehicle
    {
        public int Wings { get; set; }

        //public Airplane(string type, int wing) : base("Airplane") //depending on target
        public Airplane(string type, int wing) : base(type)
        {
            Wings = wing;
        }
    }
}
