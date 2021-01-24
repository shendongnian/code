    using System;
    using System.Diagnostics;
    namespace Demo
    {
        public class Program
        {
            static void Main()
            {
                byte[] data = new byte[90 * 1024 * 1024];
                Stopwatch sw = Stopwatch.StartNew();
                int seed = (int) DateTime.Now.Ticks;
                for (int i = 0; i < 10; ++i)
                    seed = FillWithRandomData(seed, data);
                Console.WriteLine(sw.Elapsed);
            }
            public static int FillWithRandomData(int seed, byte[] array)
            {
                unchecked
                {
                    int n = seed * 134775813 + 1;
                    for (int i = 0; i < array.Length; ++i)
                    {
                        array[i] = (byte) n;
                        n = 2147483629 * n + 2147483587;
                    }
                    return n;
                }
            }
        }
    }
