    public class SummaryFactory
    {
        public T Create<T>() where T : ISummary, new()
        {
            var result = new T();
            // add all logic that you need
             
            return result;
        }
        public T Create<T>(Action<T> action) where T : ISummary, new()
        {
            var result = new T();
            action(result);
             
            return result;
        }
        // add other factory methods for example :
        public object Create(Type type)
        {
            var result = Activator.CreateInstance(type);
            // add all logic that you need
             
            return result;
        }
    }
