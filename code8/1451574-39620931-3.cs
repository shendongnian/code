    public class SummaryFactory
    {        
        // new instance with values assigned by action delegate or default
        public T Create<T>(Action<T> action = null) 
            where T : ISummary, new()
        {
            var result = new T();
            action?.Invoke(result);
             
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
