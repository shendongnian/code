    using System;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            private static int[] bob = {1, 2, 3, 4, 0, 5, 0, 6, 7};
    
            static void Main(string[] args)
            {
                Console.WriteLine(IndexExcludingValue(bob, 6, 0));
                Console.ReadLine();
            }
    
            public static int? IndexExcludingValue(int[] test, int valueToFind, int valueToExclude)
            {
                return test.Where(z => z != valueToExclude)
                    .Select((value, index) => new {value, index})
                    .FirstOrDefault(z => z.value == valueToFind)?.index;
            }
        }
    }
