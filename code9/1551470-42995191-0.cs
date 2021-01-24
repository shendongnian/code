    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main()
            {
                for (int i = 0; i < 4; ++i)
                    Task.Run(() => withdraw(800m));
                Thread.Sleep(1000);
                // Balance should be 200 unless a race condition occured.
                Console.WriteLine(balance);
            }
            static void withdraw(decimal amount)
            {
                if (balance >= amount)
                    balance -= amount;
            }
            static decimal balance = 1000.0m;
        }
    }
