    public interface IProcessor
    {
        T Process<T>();
        void Process();
    }
    public class Processor : IProcessor
    {
        public void Process()
        {
            DoWork();
        }
        public T Process<T>()
        {
            return (T)DoWork();
        }
        public object DoWork()
        {
            // do your common tasks
        }
    }
