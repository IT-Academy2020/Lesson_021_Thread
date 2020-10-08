using System;
using System.Threading;

// Критична секція (critical section).

// lock - блокує блок коду так, що в кожен окремий момент часу, цей блок коду
// зможе використовувати тільки один потік. Всі інші потоки чекають поки поточний потік, закінчить роботу.

namespace CriticalSection
{
    class MyClass
    {
        object block = new object();

        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            lock (block) // Закоментувати lock.
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("Потік # {0}: крок {1}", hash, counter);
                    Thread.Sleep(100);
                }
                Console.WriteLine(new string('-', 20));
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

                Thread.Sleep(500);

                // Delay.
                Console.ReadKey();
            }
        }
    }
}