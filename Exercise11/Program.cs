using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleData vehicle = new VehicleData();
            Vehicle car = new Car("Lada");
            Vehicle flight = new Airplane("Boeing", 2);
            vehicle.PrintVehicle(car);
            vehicle.PrintVehicle(flight);

            Console.ReadLine();
        }
    }
}
