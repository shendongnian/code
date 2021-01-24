    public class MyWrapperClass
    {
        private Object _instance;
        public void ImportObject<T>() where T : new()
        {
            _instance = new T();
        }
        public object CallMethod(String name, object[] parameters)
        {
            var parameterTypes = parameters.Select(p => p.GetType()).ToArray();
            var methodInfo = _instance.GetType().GetMethod(name, parameterTypes);
            return methodInfo.Invoke(_instance, parameters);
        }
    }
