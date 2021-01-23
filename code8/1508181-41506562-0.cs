    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                List<int> mylist = new List<int>() { 1, 2, 0, 4, 0, 7, 0, 1 };
    
                mylist.Remove(0);
    
                Console.WriteLine(string.Join(", ", mylist));
                Console.ReadKey();
            }
        }
    }
