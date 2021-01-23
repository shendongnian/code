    using System;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var number = "12-15";
                var numbers = Array.ConvertAll(number.Split('-'), int.Parse);
                Console.WriteLine(numbers[0]);
                Console.WriteLine(numbers[1]);
            }
        }
    }
