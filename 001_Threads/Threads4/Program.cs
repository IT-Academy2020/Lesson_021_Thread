using System;
using System.Threading;

// Потоки. Передача даних в потік.

namespace Threads
{
    class Program
    {
        // Метод, який планується виконуватись в окремому потоці.
        static void WriteSecond(object argument)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(argument);
                Thread.Sleep(1000);
            }
        }

        static void Main()
        {
            ParameterizedThreadStart writeSecond = new ParameterizedThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start("Hello");

            Thread.Sleep(500);

            // Delay.
            Console.ReadKey();
        }
    }
}