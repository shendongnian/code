    using System;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var number = "12-15";
                var numbers = number.Split('-');
                var one = int.Parse(numbers[0]);
                var two = int.Parse(numbers[1]);
                Console.WriteLine(one);
                Console.WriteLine(two);
            }
        }
    }
