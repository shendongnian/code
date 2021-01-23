    public static class ObjectManager<T> where T : class, new()
    {
        // Our event handler will accept a parameter of type T and return void
        public static event Action<T> OnObjectInstantiated;
        public static T InstantiateObject() 
        {
            T obj = new T();
            OnObjectInstantiated?.Invoke(obj);
            return obj;
        }
    }
