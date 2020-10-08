using System;
using System.Threading;

// Критична секція (critical section).

// lock - це скорочене використання System.Threading.Monitor.
// Monitor.Enter (this) - блокує блок коду так, що його може використовувати тільки поточний потік.
// Решта потоки чекають поки поточний потік, закінчить роботу і викличе Monitor.Exit (this).

namespace CriticalSection
{
    class MyClass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            Monitor.Enter(block); // Закоментувати.

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine("Потік # {0}: крок {1}", hash, counter);
                Thread.Sleep(100);
            }
            Console.WriteLine(new string('-', 20));

            Monitor.Exit(block); // Закоментувати.
        }
    }

    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 40);

            MyClass instance = new MyClass();

            for (int i = 0; i < 3; i++)
            {
                new Thread(instance.Method).Start();
            }

            // Delay.
            Console.ReadKey();
        }
    }
}