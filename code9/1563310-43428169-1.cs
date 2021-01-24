    using System;
    
    namespace _50_Million
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter Number ");
                string number = Console.ReadLine();
                Console.Write("What to divide by ");
                string divide = Console.ReadLine();
                Console.Write("How many times ");
                string d = Console.ReadLine();
    
                decimal previousNumber = Convert.ToDecimal(number);
                decimal times = Convert.ToDecimal(d);
                decimal divideDecimal = Convert.ToDecimal(divide);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                decimal newNumber = 0;
    
                for (int i = 0; i < times; i++)
                {
                        newNumber = previousNumber / divideDecimal;
                        previousNumber = newNumber;           
                }
    
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
    
                Console.WriteLine("It has taken " + elapsedMs + " millisecounds to divide " + number + " by " + divide + ", " + d + " times.");
                Console.WriteLine("The Answer is " + newNumber);
                Console.ReadLine();
            }
        }
    }
