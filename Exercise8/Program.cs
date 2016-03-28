using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger myLogger = new Logger();
            myLogger.Log("First message");
            myLogger.Log("Second message");
            myLogger.Log("Third message");

            foreach(string logger in myLogger.LogPosts)
            {
                Console.WriteLine(logger);
            }

            Console.ReadKey();

        }
    }
}
