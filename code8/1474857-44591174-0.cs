    using System;
    
    public class SortProblem
    {
        public static void Main()
        {
            Sort();
            Console.ReadKey();
        }
        public static void Sort()
        {
            var a = new[]
            {
                10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
            };
            for (int i = 0, n = a.Length; i < n; i++)
            {
                int PresentMax = -2147483640, maxPos = 0, b;
                for (int j = i; j < n; j++)
                {
                    if (PresentMax < a[j])
                    {
                        PresentMax = a[j];
                        maxPos = j;
                    }
                }
                Console.Write($"{maxPos}");
                b = a[i];
                a[i] = a[maxPos];
                a[maxPos] = b;
            }
            Console.WriteLine();
            for (int i = 0, n = a.Length; i < n; i++)
            {
                Console.Write($"{a[i]} ");
            }
        }
    }
