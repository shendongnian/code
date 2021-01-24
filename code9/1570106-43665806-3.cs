    public class MyGenericWrapperClass<T> where T : new()
    {
        private T _instance;
        public void ImportObject()
        {
            _instance = new T();
        }
        public object CallMethod(String name, object[] parameters)
        {
            var parameterTypes = parameters.Select(p => p.GetType()).ToArray();
            var methodInfo = typeof(T).GetMethod(name, parameterTypes);
            return methodInfo.Invoke(_instance, parameters);
        }
    }
