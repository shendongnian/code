    public class MyClass
            {
                private static Lazy<MyClass> instance = new Lazy<MyClass>(() => new MyClass());
    
                public static MyClass Instance => instance.Value;
    
                public string Rand { get; } = (new Random()).Next(2500).ToString();
    
                private MyClass() { }
            }
