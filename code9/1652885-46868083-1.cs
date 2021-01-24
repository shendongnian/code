    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace hashExample
    {
        class Program
        {
            static int RunArray(int[] array)
            {
                int[] dp = new int[array.Length];
                dp[0] = 1;
                for (int i = 1; i < array.Length; i++)
                {
                    dp[i] = 1;
                    for (int j = 0; j < i; j++)
                        if (array[i] > array[j] && dp[i] < dp[j] + 1)
                                dp[i] = dp[j] + 1;
                }
                return dp.Max();
            }
    
            static int RunList(List<int> array)
            {
                List<int> dp = new List<int>(array.Count);
                dp.Add(1);
                for (int i = 1; i < array.Count; i++)
                {
                    dp.Add(1);
                    for (int j = 0; j < i; j++)
                        if (array[i] > array[j] && dp[i] < dp[j] + 1)
                            dp[i] = dp[j] + 1;
                }
                return dp.Max();
            }
    
            static void Main(string[] args)
            {
                int arrayLen = 1000;
                Random r = new Random();
                List<double> values = new List<double>();
                Stopwatch clock = new Stopwatch();
                Console.WriteLine("Running...");
                for (int i = 0; i < 100; i++)
                {
                    List<int> list = new List<int>();
                    int[] array = new int[arrayLen];
                    for (int j = 0; j < arrayLen;j++)
                    {
                        int e = r.Next();
                        array[j] = e;
                        list.Add(e);
                    }
                    
                    clock.Restart();
                    RunArray(array);
                    clock.Stop();
                    double timeArray = clock.ElapsedMilliseconds;
                    clock.Restart();
                    RunList(list);
                    clock.Stop();
                    double timeList = clock.ElapsedMilliseconds;
                    //Console.WriteLine(Math.Round(timeArray/timeList*100,2) + "%");
                    values.Add(timeArray / timeList);
                }
                Console.WriteLine("Arrays are " + Math.Round(values.Average()*100,1) + "% faster");
                Console.WriteLine("Done");
            }
    
            
    
        }
    }
