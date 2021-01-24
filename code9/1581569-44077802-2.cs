    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics; // This is important
    
    class Solution 
    {
        static void Main(String[] args) 
        {
            int n = int.Parse(Console.ReadLine()); // No reason to accept a double here
    
            BigInteger factorial = 1; 
    
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
    
            Console.WriteLine(factorial.ToString());
       }
    }
