    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int> { 0, 1, 2, 6, 7 };
            var bigger4 = myList           // from myList   
                .Where(item => item > 4)   // filter all bigger 4
                .OrderBy(i => i)           // order them by value ascending
                .ToList();                 // make list to allow AddRange() later
            // I am putting 4rs into this list 
            var smaller5 = myList          // from myList
                .Where(item => item <= 4)  // filter all smalller equal 4
                .OrderBy(i => i);          // order them by value ascending
            bigger4.AddRange(smaller5);    // add to first list
            // output as string with , between values:
            Console.WriteLine(string.Join(",", bigger4)); // which smaller5 added into bigger4
            Console.ReadLine();
        }
    }
