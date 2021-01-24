    using System;
    
    
    class Program
        {
            static void Main(string[] args)
            {
                string[] cijfers = new string[10] { "7", "8", "4", "6", "5.5", "7.5", "2", "3.3", "4.9", "8.9" };
                int i = 0;
                double sum=0;
                for (i = 0; i < 10; i++)
                    {
                        sum+=double.Parse(cijfers[i]);
                        Console.WriteLine("The sum is: {0}",sum);
                    }
                    Console.Write("The average is: {0}",sum/10);
                
            }
        }
