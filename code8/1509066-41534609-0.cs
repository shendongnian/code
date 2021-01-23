    using System;
    using System.Collections.Generic;
    
    namespace ImmutableLists
    {
        class Program
        {
            static void Main()
            {
                List<int> nums = new List<int>(); ;
    
                for (int i=0; i<=20; i++)
                {
                    nums.Add(i);
                    Console.WriteLine("{0} : {1}", i, nums.Capacity);
                }
    
                Console.ReadKey();
            }
        }
    }
    
