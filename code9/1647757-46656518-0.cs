    using System;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                var array = new[] {1, 2, 3, 4};
    
                Array.Sort(array);
    
                var n = array.Length;
    
                double median;
    
                var isOdd = n % 2 != 0;
                if (isOdd)
                {
                    median = array[(n + 1) / 2 - 1];
                }
                else
                {
                    median = (array[n / 2 - 1] + array[n / 2]) / 2.0d;
                }
    
                Console.WriteLine(median);
            }
        }
    }
