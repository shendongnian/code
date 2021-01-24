    using System;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                long national_debt = 19900000000000;
                long payment_size = 100000000;
                long total_days_to_pay = national_debt / payment_size;
                // if the debt is not evenly divisible by the payment size, then there is one partial day of debt
                if (national_debt % payment_size != 0)
                    total_days_to_pay++;
                Console.WriteLine("It takes " + total_days_to_pay + " total days to pay off the national debt.");
                Console.WriteLine("That's " + total_days_to_pay / 365 + " years and " + total_days_to_pay % 365 + " days !");
            }
        }
    }
