    // Compile as "x32" or "x64" (depending on the bitness of your Python), but not "Any CPU".
    using System;
    namespace NetClass
    {
        public class MyClass
        {
            public int XPlusOne(int x)
            {
                return x + 1;
            }
            public int[] XTimesTwo(int[] x)
            {
                int[] result = new int[x.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    result[i] = x[i] * 2;
                }
                return result;
            }
            public DateTime DatePlusOne(DateTime dateTime)
            {
                return dateTime.AddDays(1);
            }
        }
    }
