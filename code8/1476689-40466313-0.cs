    using System;
    namespace Demo
    {
        class Program
        {
            const int N = 1000000;
            static void Main()
            {
                var result1 = testRandom(randomA);
                var result2 = testRandom(randomB);
                Console.WriteLine("Results for randomA():\n");
                printResults(result1);
                Console.WriteLine("\nResults for randomB():\n");
                printResults(result2);
            }
            static void printResults(int[] results)
            {
                for (int i = 0; i < results.Length; ++i)
                {
                    Console.WriteLine(i + ": " + new string('*', (int)(results[i]*2000L/N)));
                }
            }
            static int[] testRandom(Func<Random, int> gen)
            {
                Random rng = new Random(12345);
                int[] result = new int[100];
                for (int i = 0; i < N; ++i)
                    ++result[gen(rng)];
                return result;
            }
            static int randomA(Random rng)
            {
                return rng.Next(1, 100);
            }
            static int randomB(Random rnd)
            {
                int random1 = rnd.Next(1, 24);
                int random2 = rnd.Next(25, 49);
                int random3 = rnd.Next(random1, random2);
                int random4 = rnd.Next(50, 74);
                int random5 = rnd.Next(75, 100);
                int random6 = rnd.Next(random4, random5);
                return rnd.Next(random3, random6);
            }
        }
    }
    
