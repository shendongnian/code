    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Program
    {
        public static decimal CalcFactDivision(int n1, int n2)
        {
            // calclulate the division of a factorial by another, num1 must be >= num2
            IEnumerable<int> getRemaining(int num1, int num2)
            {
                // special cases: div by 0 and 0 div something
                if (num2 == 0)
                    num2 = 1; // 0! == 1
                else if (num1 == 0)
                    return new[] { 0 };
                // get all numbers that make up the factorial in one step 
                // I can guarantee that num1 will always be bigger then num2
                // by how I call this
                return Enumerable.Range(num2 + 1, num1 - num2);
            }
    
            // calculate the product of an ienumerable of ints
            int product(IEnumerable<int> nums) => nums.Aggregate((a, b) => a * b);
    
            if (n1 == n2)
                return 1;
            else if (n1 > n2) // use product(...) to calc
                return product(getRemaining(n1, n2));
            else // flip them and use 1/product(...) to calc
                return (decimal)1 / product(getRemaining(n2, n1));
        }
    
        static void Main(string[] args)
        {
            foreach (var a in Enumerable.Range(1, 10))
                Console.WriteLine($"{a}! / {10 - a}! = {CalcFactDivision(a, 10 - a)} ");
    
            Console.ReadLine();
        }
    }
