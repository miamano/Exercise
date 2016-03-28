using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9B
{
    class Employer
    {
        List<Employee> employees;
        Logger logger;

        public Employer()
        {
            logger = new Logger();
            employees = new List<Employee>();
            employees.Add(new Employee("Magnus", "Andersson", "198409241234", 400));
            employees.Add(new Employee("Håkan", "Göransson", "198311111234", 420));
            employees.Add(new Employee("Sara", "Bengtsson", "197811111234", 450));
            employees.Add(new Employee("Melinda", "Bengtsson", "197811113333", 450));
        }

        public void AddNewEmployee(string firstName, string efterName, string id, double wage)
        {
            employees.Add(new Employee(firstName, efterName, id, wage));
            logger.Log("New employee is added (" + firstName + "," + efterName + ")");
        }

        public List<Employee> ListEmployees()
        {
            logger.Log("All employees are listed. ");
            return employees;
        }

        public List<Employee> GetEmployeesByYear(int year)
        {
            logger.Log("Employees in certain birthsyear (" + year + ") are listed. ");
            List<Employee> tmp = new List<Employee>();
            foreach (Employee emp in employees)
            {
                if (emp.Id.Substring(0, 4) == year.ToString())
                {
                    tmp.Add(emp);
                }
            }
            return tmp;
        }

        public Employee GetEmployee(string id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }

        public void DeleteEmployee(Employee emp)
        {
            logger.Log("One employee is deleted (" + emp.FirstName + "," + emp.LastName + ")");
            employees.Remove(emp);          
        }

        public List<string> getAllLog()
        {
            return logger.LogPosts;
        }
    }
}
