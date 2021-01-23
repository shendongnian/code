    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace CaseProblem
    {
        class CaseHelper
        {
            public static void ReadFiveNumbersToAnArray(ref int[] array)
            {
                int i;
                // loop for accepting values in array
                for (i = 0; i < 5; i++)
                {
                    Console.Write("Enter number:\t");
                    array[i] = int.Parse(Console.ReadLine());
                }
            }
            public static void WriteOutAnArrayPlease(ref int[] array)
            {
                foreach (int i in array)
                {
                    Console.Write(" {0}", i);
                }
            }
        }
        class Program
        {
            static void Main(int[] parameters)
            {
                int[] array = new int[5];
                CaseHelper.ReadFiveNumbersToAnArray(ref array);
                //sorting array value; <-- It's obvious from the method named Sort.
                Array.Sort(array); //use array's sort function <-- Again, we know this.
                CaseHelper.WriteOutAnArrayPlease(ref array);
                Console.ReadLine();
            }
        }
    }
