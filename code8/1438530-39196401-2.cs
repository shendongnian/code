    public class MyClass<T> : IMyClass {
        public MyClass(IMyClass parent = null) {
            Parent = parent;
        }
        public IMyClass Parent { get; set; }    
        // ... Additional stuff
    }
