    public class MyClass<T>
    {
        private int _counter;
        public int Id { get; private set; } 
        public int? ParentId { get; private set; } 
        public static MyClass<T> Create<T,T2>(MyClass<T2> parent = null)
        {
            var current = new MyClass<T>();
            current.Id = Atomic.Increment(ref _counter);
            current.ParentId = parent?.Id;
            return current;
        }
        private MyClass()
        {
        }
        // ... Additional stuff
    }
