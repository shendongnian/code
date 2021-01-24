    public class MyClassA : IChainedWork
    {
        private int _myAccumulator = 100;
        public MyClassA(IChainedWork next = null)
        {
            Next = next;
        }
        public int DoWork()
        {
            _myAccumulator -= 1;
            return _myAccumulator;
        }
        public IChainedWork Next { get; }
    }
