    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Strings
    {
        class Program
        {
            // method SumOfEvens take an int array and returns an int
            static int SumOfEvens(int[] integers)
            {
                //initialize results variable
                int result = 0
                //check if the number is even. If it's even, add it.
                foreach (int i in integers)
                    if (i % 2 == 0)
                    {
                        int result += i
                    }
                // You should return the result
                return result;
            }
            static void Main(string[] args)
            {
                // that's how you create an array of integers in c#
                int[] integers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            
                // store the sum in a variable
                int result = SumOfEvens(integers);
                // write result to the console
                Console.WriteLine("The sum of even integers is: "+ result);
            
                // never return something in the Main method
                // because it returns void (nothing)
            }
        }
    }
