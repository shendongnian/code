    using System;
    
    namespace _50_Million
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter Number ");
                double number = Convert.ToInt64(Console.ReadLine());
                Console.Write("What to divide by ");
                double divide = Convert.ToInt64(Console.ReadLine());
                Console.Write("How many times ");
                int d = Convert.ToInt32(Console.ReadLine());
    
                var watch = System.Diagnostics.Stopwatch.StartNew();
                double newNumber = 0;
                double previousNumber = number;
    
                for (int i = 0; i < d; i++)
                {
                        newNumber = previousNumber / divide;
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
