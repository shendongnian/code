    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace RemoveItemFromListWithLinq_42565975
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoIt();
            }
    
            private static void DoIt()
            {
                List<string> thelist = new List<string>() { "file1", "file2", "file3" };
                thelist = thelist.Where(p => p.Length == 5 && p != "file2" ).ToList();
                Console.WriteLine(string.Join(",", thelist));
                Console.ReadLine();
            }
        }
    }
