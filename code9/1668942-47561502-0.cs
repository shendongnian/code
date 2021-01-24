    using System;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                long initial_national_debt = 19900000000000;
                long national_debt = initial_national_debt;
                long payment_size = 100000000;
                while (national_debt > 0)
                {
                    Console.WriteLine(national_debt);
                    national_debt -= payment_size;
                }
            }
        }
    }
