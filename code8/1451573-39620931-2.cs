    public class SummaryFactory
    {
        // new instance with default values
        public T Create<T>() where T : ISummary, new()
        {
            var result = new T();
            // add all logic that you need
             
            return result;
        }
        // new instance with values assigned by action delegate
        public T Create<T>(Action<T> action) where T : ISummary, new()
        {
            var result = new T();
            action(result);
             
            return result;
        }
        new instance without generic parameters
        public object Create(Type type)
        {
            var result = Activator.CreateInstance(type);
            // add all logic that you need
             
            return result;
        }
    }
