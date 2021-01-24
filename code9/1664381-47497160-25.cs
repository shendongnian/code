    internal class Program
    {
        private int _maxDepth;
        private UIntPtr _stackStart;
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int Calculate(int depth)
        {
            try
            {
                Console.WriteLine("In try at depth {0}: stack frame count = {1}, stack offset = {2}",depth, new StackTrace().FrameCount, GetLooseStackOffset());
                if (depth >= _maxDepth)
                    throw new InvalidOperationException("Max. recursion depth reached.");
                return Calculate2(depth + 1);
            }
            catch
            {
                Console.WriteLine("In catch at depth {0}: stack frame count = {1}, stack offset = {2}", depth, new StackTrace().FrameCount, GetLooseStackOffset());
                throw;
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private int Calculate2(int depth) => Calculate(depth);
        public void Run()
        {
            try
            {
                _stackStart = GetSomePointerNearTheTopOfTheStack();
                _maxDepth = 10;
                Calculate(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Finished with " + e.GetType());
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe UIntPtr GetSomePointerNearTheTopOfTheStack()
        {
            int dummy;
            return new UIntPtr(&dummy);
        }
        private int GetLooseStackOffset() => (int)((ulong)_stackStart - (ulong)GetSomePointerNearTheTopOfTheStack());
        public static void Main() => new Program().Run();
    }
