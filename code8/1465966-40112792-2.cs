    public interface IProcessor
    {
        T Process<T>() where T : class;
    }
    public class Processor : IProcessor
    {
        public T Process<T>() where T : class
        {
            var result = (T)DoWork();
            if (typeof(T) == typeof(Process2))
                return result;
            return null;
        }
        public object DoWork()
        {
            // do your common tasks
        }
    }
