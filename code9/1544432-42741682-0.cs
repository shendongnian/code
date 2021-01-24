    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        public static class Program
        {
    
            public static long Success;
            public static long Failure;
            public static long TotalIterations;
            public static long TotalCallsToRandom;
            public static readonly int CurrentSeed = Environment.TickCount;
            public static Random Random = new Random(CurrentSeed);
            public static Stopwatch TotalSimulationTime = new Stopwatch();
            public static Stopwatch ReportWatchTime = new Stopwatch();
            public static bool IsRunning = true;
    
            //
            public const int TotalTestingIndices = 7;
            public const int MaximumTestingValue = 31;
            public const int TimeBetweenReports = 30000; // Report every 30 Seconds.
            //
    
            public static void Main(string[] args)
            {
                int[] array = new int[TotalTestingIndices];
                TotalSimulationTime.Start();
                ReportWatchTime.Start();
                while (IsRunning)
                {
                    if (ReportWatchTime.ElapsedMilliseconds >= TimeBetweenReports)
                    {
                        Report();
                        ReportWatchTime.Restart();
                    }
                    Fill(array);
                    if (IsPerfect(array))
                    {
                        Success++;
                        Console.WriteLine("A Perfect Array was found!");
                        PrintArray(array);
                        Report();
                        IsRunning = false;
                    }
                    else
                    {
                        Failure++;
                    }
                    TotalIterations++;
                }
                Console.Read();
            }
    
            public static void Report()
            {
                Console.WriteLine();
                Console.WriteLine("## Report ##");
                Console.WriteLine("Current Seed: " + CurrentSeed);
                Console.WriteLine("Desired Perfect Number: " + MaximumTestingValue);
                Console.WriteLine("Total Testing Indices: " + TotalTestingIndices);
                Console.WriteLine("Total Simulation Time: " + TotalSimulationTime.Elapsed);
                Console.WriteLine("Total Iterations: " + TotalIterations);
                Console.WriteLine("Total Random.NextInt() Calls: " + TotalCallsToRandom);
                Console.WriteLine("Success: " + Success);
                Console.WriteLine("Failure: " + Failure);
                Console.WriteLine("## End of Report ##");
                Console.WriteLine();
            }
    
            public static void PrintArray(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                    if (i != array.Length - 1)
                    {
                        Console.Write(",");
                    }
                }
            }
    
            /// <summary>
            /// Optimized to terminate quickly.
            /// </summary>
            /// <param name="array"></param>
            /// <returns></returns>
            public static bool IsPerfect(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != MaximumTestingValue)
                    {
                        return false;
                    }
                }
                return true;
            }
    
            public static void Fill(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Random.Next(MaximumTestingValue + 1);
                    TotalCallsToRandom++;
                }
            }
        }
    }
