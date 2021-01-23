    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace StackOverflowSnippets
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ----------------------------------------------------------------------------------
                // The code you are interested in starts below this line
                const Int32 N = 100;
                Int32 nLowerBound = (90 * N) / 100; Int32 nUpperBound = (110 * N) / 100;
    
                Random rnd = new Random();
                Int32 runningSum = 0;
                Int32 nextIndex = 0;
    
                List<Int32> inputList = GenerateRandomList( /* entries = */ 1000);
                List<Int32> o = new List<Int32>();
    
                while (runningSum < nLowerBound)
                {
                    nextIndex = rnd.Next(inputList.Count); if (nUpperBound < (runningSum + inputList[nextIndex])) continue;
    
                    runningSum += inputList[nextIndex];
                    o.Add(inputList[nextIndex]);
                    inputList.RemoveAt(nextIndex);
                }
                // The code you are interested in ends above this line
                // ----------------------------------------------------------------------------------
    
                StringBuilder b = new StringBuilder();
                
                for(Int32 i = 0; i < o.Count;i++)
                {
                    if (b.Length != 0) b.Append(",");
                    b.Append(o[i].ToString());
                }
    
                Console.WriteLine("Exact N    : " + N);
                Console.WriteLine("Upper Bound: " + nUpperBound);
                Console.WriteLine("Lower Bound: " + nLowerBound);
                Console.WriteLine();
    
                Console.WriteLine("sum(" + b.ToString() + ")=" + GetSum(o).ToString());
                Console.ReadLine();
            }
    
            // -------------------------------------------------------------------
            #region Helper methods
            private static object GetSum(List<int> o)
            {
                Int32 sum = 0;
    
                foreach (Int32 i in o) sum += i;
    
                return sum;
            }
            private static List<Int32> GenerateRandomList(Int32 entries)
            {
                List<Int32> l = new List<Int32>();
    
                for(Int32 i = 1; i < entries; i++)
                {
                    l.Add(i);
                }
    
                return l;
            }
            #endregion
        }
    }
