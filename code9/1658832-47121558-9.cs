    using System;
    namespace Stackoverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] myArr = { 5, 17, 23, 9, 8, 10 };
                ReturnSorted(myArr);
            }
    
            public static int[] ReturnSorted(int[] secondArr)
            {
                int[] sorted = new int[secondArr.Length];
                for (int i = 0; i < secondArr.Length; i++)
                {
                    sorted[i] = secondArr[i];
                }
                Array.Sort(sorted);
                return sorted;
            }
        }
    }
