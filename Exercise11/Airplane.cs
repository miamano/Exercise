using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class Airplane : Vehicle
    {
        public int Wings { get; set; }

        public Airplane(string type, int wing) : base(type)
        {
            Wings = wing;
        }

        public override string DescribeVehicle()
        {
            return base.DescribeVehicle() + string.Format("with <{0}> wings.", Wings);
        }
    }
}
