    public interface IMyInterface: IComparable
    {
        int DoWork();
    }
    public class MyClassA : IMyInterface
    {
        private int _myAccumulator = 100;
        public int CompareTo(object obj)
        {
            return this.GetType().Name.CompareTo(obj.GetType().Name);
        }
        public int DoWork()
        {
            _myAccumulator -= 1;
            return _myAccumulator;
        }
    }
    public class MyClassB : IMyInterface
    {
        private int _myAccumulator = 50;
        public int CompareTo(object obj)
        {
            return this.GetType().Name.CompareTo(obj.GetType().Name);
        }
        public int DoWork()
        {
            _myAccumulator -= 1;
            return _myAccumulator;
        }
    }
    public class MyWorker
    {
        private List<IMyInterface> _myAccumulatorClasses = new List<IMyInterface> { new MyClassA(), new MyClassB() };
    
    public void CallClasses()
        {
            _myAccumulatorClasses.Sort();
            foreach (var accumulator in _myAccumulatorClasses)
            {
                var value = accumulator.DoWork();
                if (value > 0)
                    break;  // Don't call next accumulator if we get a value greater than zero back.
            }
        }
    }
