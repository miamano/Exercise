using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    abstract class Vehicle
    {
        private string type;

        public Vehicle(string type)
        {
            this.type = type;
        }

        public virtual string DescribeVehicle()
        {
            return string.Format("This vehicle is a <{0}> ", type);
        }
    }
}
