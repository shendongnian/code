    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    namespace Experiments
    {
        [MemoryDiagnoser]
        public class Test
        {
            const int SIZE = 4096;
            static byte[] _blank = new byte[SIZE];
            static byte[] _array = new byte[SIZE];
    
            [Benchmark]
            public void ArrayClear()
            {
                Array.Clear(_array, 0, SIZE);
            }
    
            [Benchmark]
            public void BlockCopy()
            {
                Buffer.BlockCopy(_blank, 0, _array, 0, SIZE);
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                BenchmarkRunner.Run<Test>();
            }
        }
    }
