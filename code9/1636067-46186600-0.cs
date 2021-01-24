    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fullList = new List<object> { 1, "bob2", "bob3", 4 };
    
                var subsetOfFullList = new HashSet<object> { fullList[3], fullList[1] };
    
                var filteredList = fullList.Where(z => subsetOfFullList.Contains(z)).ToList();
    
                Console.WriteLine(string.Join(",", filteredList));
                Console.ReadLine();
            }
        }
    }
