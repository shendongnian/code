    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Test
    {
        public class Program
        {
            static void Main()
            {
                var listA = new List<int>() { 1, 2, 3, 4, 5 };
                var listB = new List<int>() { 1, 2, 3, 4, 5 };
                var combined = listA.Zip(listB, (first, second) => new { first, second })
                    .TakeWhile(z => z.first >= z.second); ;
                var countWhereListIsGreater = combined.Count();
                var index = (countWhereListIsGreater >= listA.Count || 
                    countWhereListIsGreater >= listB.Count)
                    ? -1
                    : countWhereListIsGreater;
                Console.WriteLine(index);
                Console.ReadLine();
            }
        }
    }
