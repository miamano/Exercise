using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class VehicleData
    {
        public VehicleData() { }

        public void PrintVehicle(Vehicle v)
        {
            Console.WriteLine(v.DescribeVehicle());
        }
    }
}
