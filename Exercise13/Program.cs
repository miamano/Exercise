using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.Clear();
                Console.Write("Your name: ");
                string name = Console.ReadLine();
                DateTime birthday = InputBirthday("Birthday (YYYYMMDD): ");

                Console.WriteLine("Hello {0}.", name);

                int age = DateTime.Now.Year - birthday.Year;
                if (DateTime.Now.Month < birthday.Month)
                    age--;

                DateTime nextYearBirthday = birthday.AddYears(age + 1);
                int next = nextYearBirthday.Year - birthday.Year;
                TimeSpan days = nextYearBirthday.Subtract(DateTime.Today);

                DateTime hundredYearBirthday = birthday.AddYears(100);


                Console.WriteLine("You are {0} years old, and will turn {1} in {2} days.", age, next, days.TotalDays);
                Console.WriteLine("Your 100th birthday will be on the {0}, {1}.", hundredYearBirthday.ToString("d"), hundredYearBirthday.DayOfWeek);
                Console.WriteLine();

                
                Console.WriteLine("Stretch task");
                Console.WriteLine("Check LongDate: {0}", birthday.ToLongDateString()); //den 7 november 1975
                Console.WriteLine("Check LongTime: {0}", birthday.ToLongTimeString()); //00:00:00
                Console.WriteLine("Check ShortDate: {0}", birthday.ToShortDateString()); //1975-11-07
                Console.WriteLine("Check ShortTime: {0}", birthday.ToShortTimeString()); //00:00
                Console.WriteLine(DateTime.Now.ToString());

                Console.ReadLine();

            }
        }

        private static DateTime InputBirthday(String text)
        {
            int number = 0;
            bool isValid = false;
            int year = 0;
            int month = 0;
            int day = 0;
            while (!isValid)
            {
                Console.Write(text);
                isValid = int.TryParse(Console.ReadLine(), out number);
                isValid = number < 20160430 && number > 19000101 ? true : false;
                if (!isValid)
                {
                    Console.WriteLine("Check the lenght of birthday.");
                    continue;
                }
                year = number / 10000; 
                int tmp = number % 10000; 
                month = tmp / 100; 
                day = tmp % 100; 
                isValid = (isValid && year > 1900 && year < 2016
                                   && month >= 1 && month <= 12
                                   && day >= 1 && day <= 31) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid birthday.");
            }
            return new DateTime(year, month, day);
        }
    }
}
