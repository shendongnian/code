    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Bob
    {
        public class Program
        {
            private static IEnumerable<Combination> GetData()
            {
                for (int a = 0; a < 101; a++)
                {
                    for (int b = 0; b < 101; b++)
                    {
                        for (int c = 0; c < 101; c++)
                        {
                            for (int d = 0; d < 101; d++)
                            {
                                for (int e = 0; e < 101; e++)
                                {
                                    for (int f = 0; f < 101; f++)
                                    {
                                        for (int g = 0; g < 101; g++)
                                        {
                                            for (int h = 0; h < 101; h++)
                                            {
                                                for (int i = 0; i < 101; i++)
                                                {
                                                    var sum = a + b + c + d + e + f + g + h + i;
    
                                                    if (sum == 100)
                                                    {
                                                        yield return new Combination(a, b, c, d, e, f, g, h, i);
                                                    }
                                                    else if (sum > 100)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                var sampleResults = GetData().Take(200); // this will show 200 (remove .Take(100) to show them all)
    
                foreach (var result in sampleResults)
                {
                    Console.WriteLine(result);
                }
                Console.ReadLine();
            }
        }
    
        public class Combination
        {
            public readonly int V1;
            public readonly int V2;
            public readonly int V3;
            public readonly int V4;
            public readonly int V5;
            public readonly int V6;
            public readonly int V7;
            public readonly int V8;
            public readonly int V9;
    
            public Combination(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9)
            {
                V1 = v1;
                V2 = v2;
                V3 = v3;
                V4 = v4;
                V5 = v5;
                V6 = v6;
                V7 = v7;
                V8 = v8;
                V9 = v9;
            }
    
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", V1, V2, V3, V4, V5, V6, V7, V8, V9);
            }
        }
    }
