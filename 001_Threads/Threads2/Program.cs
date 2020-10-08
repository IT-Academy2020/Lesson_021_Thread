using System;
using System.Threading;

// Потоки.

namespace Threads
{
    class Program
    {
        // Статичний метод, який планується виконуватись одночасно в головному і в окремому потоках.
        static void WriteSecond()
        {
            // CLR призначає кожному потоку свій стек і методи мають свої власні локальні змінні.
            // Окремий екземпляр counter створюється в стеці кожного потоку,
            // тому для кожного потоку виводяться, свої значення counter - 0,1,2.
            int counter = 0;

            while (counter < 10)
            {
                Console.WriteLine("Thread Id {0}, counter = {1}", Thread.CurrentThread.GetHashCode(), counter);
                counter++;
            }
        }

        static void Main()
        {
            // Робота у додатковому потоці.
            Thread thread = new Thread(WriteSecond);
            thread.Start();

            // Робота у первинному потоці.
            WriteSecond();


            // Delay.
            Console.ReadKey();
        }
    }
}