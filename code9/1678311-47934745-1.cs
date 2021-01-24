    class Program
    {
        internal interface IFastProcessor
        {
            void Process(int i);
        }
        internal sealed class FastProcessorImpl : IFastProcessor
        {
            private int number;
            public FastProcessorImpl(int number)
            {
                this.number = number;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Process(int i)
            {
                number = ((number + i) / (number + i)) * number;
            }
        }
        internal sealed class FastProcessor
        {
            private int number;
            public FastProcessor(int number)
            {
                this.number = number;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Process(int i)
            {
                number = ((number + i) / (number + i)) * number;
            }
        }
        static void Main(string[] args)
        {
            var sw1 = new Stopwatch();
            var processor1 = new FastProcessor(10);
            sw1.Start();
            for (int i = 1; i < 10000000; i++)
            {
                processor1.Process(i);
            }
            sw1.Stop();
            var sw2 = new Stopwatch();
            var processor2 = (IFastProcessor)new FastProcessorImpl(10);
            sw2.Start();
            for (int i = 1; i < 10000000; i++)
            {
                processor2.Process(i);
            }
            sw2.Stop();
            var number = 10;
            var sw3 = new Stopwatch();
            sw3.Start();
            for (int i = 1; i < 10000000; i++)
            {
                number = ((number + i) / (number + i)) * number;
            }
            sw3.Stop();
            Console.WriteLine($"Class: {sw1.ElapsedMilliseconds}ms, Interface: {sw2.ElapsedMilliseconds}ms, Inline: {sw3.ElapsedMilliseconds}ms");
        }
    }
