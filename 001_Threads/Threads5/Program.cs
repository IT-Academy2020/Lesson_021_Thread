using System;
using System.Threading;

// Потоки. Анонімні методи.

namespace Threads
{
    class Program
    {
        static void Main()
        {
            int counter = 0;

            // ThreadStart
            Thread thread = new Thread(delegate () { Console.WriteLine("1. Counter = {0}", ++counter); });
            thread.Start();

            Thread.Sleep(100);
            Console.WriteLine("2. Counter = {0}", counter);

            // ParameterizedThreadStart
            thread = new Thread((object argument) => { Console.WriteLine("3. counter = {0}", (int)argument); });
            thread.Start(counter);

            // Delay.
            Console.ReadKey();
        }
    }
}