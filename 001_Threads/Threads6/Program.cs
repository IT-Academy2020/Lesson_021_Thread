using System;
using System.Threading;

// Основні і фонові потоки. За замовчуванням властивість IsBackground = false.

namespace Threads
{
    class Program
    {
        // Метод, який планується виконуватись в окремому потоці.
        static void WriteSecond()
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 15) + "Secondary");
                Thread.Sleep(500);
            }
        }

        static void Main()
        {
            // Робота додаткового потоку.
            ThreadStart writeSecond = new ThreadStart(WriteSecond);
            Thread thread = new Thread(writeSecond);
            thread.Start();

            // Робота первинного потоку.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Primary");
                Thread.Sleep(500);
            }

            // Завершити роботу додаткового потоку
            //thread.IsBackground = true;
        }
    }
}