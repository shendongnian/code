    public class MyImplementationDict
    {
        private readonly Dictionary<Type, object> _internalDict = new Dictionary<Type, object>();
        public void Add<T>(IImplementation<T> item)
            where T : IModel
        {
            _internalDict.Add(typeof(T), item);
        }
        ...
    }
