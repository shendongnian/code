    public class ObjectManager
    {
        public class TypeEvent
        {
            public event Action OnObjectInstantiated;
            public void RaiseObjectInstantiated()
            {
                OnObjectInstantiated?.Invoke();
            }
        }
        private static Dictionary<Type, TypeEvent> _typeMap = new Dictionary<Type, TypeEvent>();
        public static TypeEvent ForType<T>() where T: class, new()
        {
            
            Type t = typeof(T);
            if (!_typeMap.ContainsKey(t))
            {
                _typeMap[t] = new TypeEvent();
            }
            return _typeMap[t];
            
        }
        public static T InstantiateObject<T>() where T: class, new()
        {
            T obj = new T();
            ForType<T>().RaiseObjectInstantiated();
            return obj;
        }
    }
