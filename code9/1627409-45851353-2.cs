    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string space = " ";
                string a = "One";
                string b = "Two";
                string c = "Three";
                var filteredList = (new List<string> { space, a, b, c }).Where(x => !string.IsNullOrWhiteSpace(x));
                string abc = string.Join(", ", filteredList);
                Console.WriteLine(abc); //One, Two, Three
                Console.ReadKey();
            }
        }
    }
