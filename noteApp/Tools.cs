using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteApp
{
    internal class Tools
    {
        private const int WAIT_TIME = 1400;

        public static void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Wait(WAIT_TIME);
        }
        public static void Announcement(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Wait(WAIT_TIME);
        }
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Wait(WAIT_TIME);
        }
    }
}
