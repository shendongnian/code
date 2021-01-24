    internal class Program
    {
        private int _maxDepth;
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int Calculate(int depth)
        {
            try
            {
                Console.WriteLine("In try at depth {0}: stack frame count = {1}", depth, new StackTrace().FrameCount);
                if (depth >= _maxDepth)
                    throw new InvalidOperationException("Max. recursion depth reached.");
                return Calculate2(depth + 1);
            }
            catch
            {
                Console.WriteLine("In catch at depth {0}: stack frame count = {1}", depth, new StackTrace().FrameCount);
                throw;
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int Calculate2(int depth) => Calculate(depth);
        public void Run()
        {
            try
            {
                _maxDepth = 10;
                Calculate(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Finished with " + e.GetType());
            }
        }
        public static void Main() => new Program().Run();
    }
