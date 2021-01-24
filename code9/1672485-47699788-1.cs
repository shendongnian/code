    using System;
    using Microsoft.VisualBasic.Devices;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var test = new Program();
                Console.WriteLine($"Is 64 Bit Process: {Environment.Is64BitProcess}");
                Console.WriteLine($"Total Virtual Memory: {test.GetTotalVirtualMemory()}");
                Console.WriteLine($"Total Virtual Memory Readable: {test.GetTotalVirtualMemory() * (1.0 / 1024.0 / 1024.0 / 1024.0)}");
            }
    
            public ulong GetTotalVirtualMemory()
            {
                return new ComputerInfo().TotalVirtualMemory;
            }
        }
    }
