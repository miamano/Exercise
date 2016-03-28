using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    class LogApplication
    {
        private ILogger iLogger;

        public LogApplication(ILogger iLogger)
        {
            this.iLogger = iLogger;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Add message to log");
                Console.WriteLine("2) Print log");
                Console.WriteLine("3) Exit");
                int choice = InputInt("Choice: ");

                switch (choice)
                {
                    case 1:
                        Console.Write("Your message: ");
                        string message = Console.ReadLine();
                        //iLogger.Log("Choice 1 was chosen. *** " + message);
                        iLogger.Log(message);
                        break;

                    case 2:
                        //iLogger.Log("Choice 2 was chosen.");
                        foreach (string post in iLogger.LogPosts)
                        {
                            Console.WriteLine("{0}", post);
                        }
                        Console.ReadLine();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        private static int InputInt(String text)
        {
            int number = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(text);
                isValid = int.TryParse(Console.ReadLine(), out number);
                isValid = (isValid && (number <= 3) && (number > 0)) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid choice.");
            }
            return number;
        }
    }
}
