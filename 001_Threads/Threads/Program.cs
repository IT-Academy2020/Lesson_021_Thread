using System;
using System.Threading;

// Потоки.

namespace Threads
{
    class Program
    {
        // Метод, який планується виконуватись в окремому потоці.
        static void WriteSecond()
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 10) + "Secondary");
            }
        }

        static void Main()
        {
            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();

            while (true)
            {
                Console.WriteLine("Primary");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}