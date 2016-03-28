using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class Car : Vehicle
    {
        private bool engineIsRunning;

        //public Car(string type) : base("Car") //depending on target
        public Car(string type) : base(type)
        {
            engineIsRunning = false;
        }

        public void StartEngine()
        {
            engineIsRunning = true;
        }

        public void StopEngine()
        {
            engineIsRunning = false;
        }

    }
}
