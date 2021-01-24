    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int> { 0, 1, 2, 6, 7 };
            var newList = l                // from l   
                .Where(item => item > 4)   // filter all bigger 4
                .OrderBy(i => i)           // order them by value ascending
                .ToList();                 // make list to allow AddRange() later
            var newList2 = l               // from l
                .Where(item => item <= 4)  // filter all smalller equal 4
                .OrderBy(i => i);          // order them by value ascending
            newList.AddRange(newList2);    // add to first list
            // output as string with , between values:
            Console.WriteLine(string.Join(",", newList));
            Console.ReadLine();
        }
    }
