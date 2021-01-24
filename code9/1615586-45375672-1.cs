    public class MyType
    {
        private readonly static Dictionary<int, MyType> instances
           = new Dictionary<int, MyType>();
        public static MyType CreateNew(int id)
        {
            if (instances.TryGetValue(id, out var instance)
                return instance;
            return new MyType(id);
        }
        private MyType(int id) { ... }
        public int UniqueId { get; }
    }
