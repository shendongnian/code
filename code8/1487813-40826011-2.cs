    public static class ObjectManager
    {
        public class TypeEvent<T>
        {
            // Our event handler will accept a parameter of type T and return void
            public event Action<T> OnObjectInstantiated;
            public void RaiseObjectInstantiated(T obj)
            {
                OnObjectInstantiated?.Invoke(obj);
            }
        }
        private static Dictionary<Type, object> _typeMap = new Dictionary<Type, object>();
        public static TypeEvent<T> ForType<T>() where T: class, new()
        {
            
            Type t = typeof(T);
            if (!_typeMap.ContainsKey(t))
            {
                _typeMap[t] = new TypeEvent<T>();
            }
            return _typeMap[t] as TypeEvent<T>;
            
        }
        public static T InstantiateObject<T>() where T: class, new()
        {
            T obj = new T();
            ForType<T>().RaiseObjectInstantiated(obj);
            return obj;
        }
    }
