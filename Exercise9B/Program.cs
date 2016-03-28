using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9B
{
    class Program
    {
        private const int FILTER_YEAR_MIN = 1920;
        private const int FILTER_YEAR_MAX = 2016;
        private const int FILTER_MONTH_1 = 0;
        private const int FILTER_MONTH_12 = 13;
        private const int FILTER_DAY_1 = 0;
        private const int FILTER_DAY_31 = 32;

        private Employer employer;

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.employer = new Employer();

            bool isContinue = true;
            while (isContinue)
            {
                pr.DrawMeny();

                bool isValidChoice = false;
                string choice = string.Empty;
                while (!isValidChoice)
                {
                    Console.Write("Select an option: ");
                    choice = Console.ReadLine();
                    choice = choice.ToUpper();
                    isValidChoice = (choice == "A" || choice == "L" || choice == "S" || choice == "D" || choice == "H" || choice == "E") ? true : false;
                }

                pr.HandleMenyChoice(choice);


                bool isValidChar = false;
                while (!isValidChar)
                {
                    string text = "Continue y/n? ";
                    Console.WriteLine();
                    pr.DrawLine(text.Length);
                    Console.Write(text);
                    string cont = Console.ReadLine();
                    isValidChar = (cont.ToUpper() == "N" || cont.ToUpper() == "Y") ? true : false;
                    isContinue = (isValidChar && cont.ToUpper() == "Y") ? true : false;
                }
            }
        }

        private void HandleMenyChoice(string choice)
        {
            switch (choice)
            {
                case "A":
                    AddNewEmployee();
                    break;

                case "L":
                    ListAllEmployees();
                    break;

                case "S":
                    SearchWithFilter();
                    break;

                case "D":
                    DeleteEmployee();
                    break;

                case "H":
                    LogHistory();
                    break;

                case "E":
                    Environment.Exit(0);
                    break;

                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void AddNewEmployee()
        {
            DrawTitle("   ADD A NEW EMPLOYEE   ");
            Console.Write("Firstname: ");
            string tmpFirstName = Console.ReadLine();
            Console.Write("Lastname: ");
            string tmpLastName = Console.ReadLine();
            string tmpId = InputId("ID number (YYYYMMDDXXXX): ");
            double tmpWage = InputWage("Hourly wage: ");

            employer.AddNewEmployee(tmpFirstName, tmpLastName, tmpId, tmpWage);
            DrawLine(20);
            Console.WriteLine("");
            Employee emp = employer.GetEmployee(tmpId);
            Console.WriteLine("Bekräftelse om {0} added to employees.", (emp != null) ? emp.GetFullName() : "NOT");
        }

        private void ListAllEmployees()
        {
            DrawTitle("    LIST ALL EMPLOYEES    ");
            Console.WriteLine("    Firstname\t Lastname\t ID\t         Hourly wage");

            List<Employee> employees = employer.ListEmployees();
            int i = 0;
            foreach (Employee emp in employees)
            {
                Console.Write("({0}) {1,-10}\t {2,-10}\t {3}\t {4}\n", i + 1, emp.FirstName, emp.LastName, emp.Id, emp.HourlyWage);
                i++;
            }
        }

        private void SearchWithFilter()
        {
            DrawTitle("    SEARCH WITH FILTER    ");
            int year = InputYear("Enter year (YYYY): ");
            DrawLine(26);
            Console.WriteLine("");

            List<Employee> employees = employer.GetEmployeesByYear(year);
            if (employees.Count > 0)
            {
                Console.WriteLine("    Firstname\t Lastname\t ID\t         Hourly wage");
                int i = 0;
                foreach (Employee emp in employees)
                {
                    Console.Write("({0}) {1,-10}\t {2, -10}\t {3}\t {4}\n", i + 1, emp.FirstName, emp.LastName, emp.Id, emp.HourlyWage);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Could not found anyone");
            }

        }

        private void DeleteEmployee()
        {
            DrawTitle("   DELETE AN EMPLOYEE   ");
            string tmpId = InputId("Enter ID number: ");
            DrawLine(20);
            Console.WriteLine("");
            Employee emp = employer.GetEmployee(tmpId);
            Console.WriteLine("Bekräftelse om employee {0} is deleted.", (emp != null) ? emp.GetFullName() : "NOT");
            if (emp != null)
            {
                employer.DeleteEmployee(emp);
            }
        }

        private void LogHistory()
        {
            DrawTitle("   LOG HISTORY   ");
            Console.WriteLine("");
            List<string> logs = employer.getAllLog();
            foreach (string log in logs)
            {
                Console.WriteLine(log);
            }
        }

        private int InputYear(String text)
        {
            int number = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine(text);
                isValid = int.TryParse(Console.ReadLine(), out number);
                isValid = (isValid && number > 1900 && number < 2016) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid YEAR.");
            }
            return number;
        }

        private string InputId(String text)
        {
            long number = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(text);
                isValid = long.TryParse(Console.ReadLine(), out number);
                long tmp = number;
                int last4 = (int) tmp % 10000;
                tmp /= 10000;
                int day = (int) tmp % 100;
                tmp /= 100;
                int month = (int) tmp % 100;
                tmp /= 100;
                int year = (int) tmp % 10000;

                isValid = (isValid && tmp > FILTER_YEAR_MIN && tmp < FILTER_YEAR_MAX
                                   && month > FILTER_MONTH_1 && month < FILTER_MONTH_12
                                   && day > FILTER_DAY_1 && day < FILTER_DAY_31) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid ID.");
            }
            return number.ToString();
        }

        private double InputWage(String text)
        {
            double number = 0.0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(text);
                isValid = double.TryParse(Console.ReadLine(), out number);
                isValid = (isValid && number > 0) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid wage.");
            }
            return number;
        }

        private void DrawMeny()
        {
            Console.Clear();
            DrawLine(22);
            Console.WriteLine("(A)dd new employee");
            Console.WriteLine("(L)ist employees");
            Console.WriteLine("(S)how filtered search");
            Console.WriteLine("(D)elete an employee");
            Console.WriteLine("(H)istory of logs");
            Console.WriteLine("(E)xit");
            DrawLine(22);
        }

        private void DrawTitle(string title)
        {
            Console.Clear();
            DrawLine(title.Length);
            Console.WriteLine(title);
            DrawLine(title.Length);
        }

        private void DrawLine(int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-");
        }
    }
}
