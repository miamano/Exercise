using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9B
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public double HourlyWage { get; set; }
        
        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Id = string.Empty;
            HourlyWage = 0.0;
        }

        public Employee(string firstName, string lastName, string id, double hourlyWage)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            HourlyWage = hourlyWage;
        }

        public Employee(string id)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Id = id;
            HourlyWage = 0.0;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
