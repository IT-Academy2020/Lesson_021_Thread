using System;
using System.Threading;

// Потоки.

namespace Threads
{
    class Program
    {
        static void WriteSecond()
        {
            // Thread.CurrentThread - повертає посилання на екземпляр поточного потоку.
            Thread thread = Thread.CurrentThread;

            // Надаємо потоку ім'я.
            thread.Name = "Secondary";

            // Виводимо на екран інформацію про поточний потік.
            Console.WriteLine("ID потоку {0}: {1}", thread.Name, thread.GetHashCode());

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine(new string(' ', 15) + thread.Name + "" + counter);
                // Призупиняємо виконання поточного потоку.
                Thread.Sleep(1000);
            }
        }

        static void Main()
        {
            // Отримуємо посилання на екземпляр поточного потоку.
            Thread primaryThread = Thread.CurrentThread;

            // Надаємо потоку ім'я.
            primaryThread.Name = "Primary";

            // Виводимо на екран інформацію про поточний потік.
            Console.WriteLine("ID потоку {0}: {1}", primaryThread.Name, primaryThread.GetHashCode());


            // Робота додаткового потоку.
            Thread secondaryThread = new Thread(WriteSecond);
            secondaryThread.Start();

            // Робота первинного потоку.
            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine(primaryThread.Name + "" + counter);
                // Призупиняємо виконання поточного потоку.
                Thread.Sleep(1500);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}