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
    
            public static int[] ReturnSorted(int[] arr) {
                int[] sorted = arr;
                Array.Sort(sorted);
                return sorted;
            }
        }
    }
