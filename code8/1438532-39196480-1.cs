    public class MyClass<T>
    {
        public int Id { get; private set; }
        public int? ParentId { get; private set; }
        public static MyClass<T> Create(int id)
        {
            return Create<object>(id, null);
        }
        public static MyClass<T> Create<T2>(int id, MyClass<T2> parent = null)
        {
            var current = new MyClass<T>();
            current.Id = id;
            current.ParentId = parent?.Id;
            return current;
        }
        private MyClass()
        {
        }
        // ... Additional stuff
    }
