    public class SummaryFactory
    {
        public T Create<T>() where T : ISummary, new()
        {
            var result = new T();
            // add all logic that you need
             
            return result;
        }
    }
