    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication32
    {
        internal class Program
        {
            public static async Task<int> Print1()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("x");
                    await Task.Delay(10);
                }
                return 1;
            }
    
            public static async Task<int> Print2()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("y");
                    await Task.Delay(10);
                }
                return 1;
            }
    
            public static async Task Run()
            {
                var i = Print1();
                var k = Print2();
    
                await Task.WhenAll(i, k);
            }
    
            private static void Main(string[] args)
            {
                Task.Run(async () => await Run()).Wait();
            }
        }
    }
