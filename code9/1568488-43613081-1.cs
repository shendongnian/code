    public interface IMyInterface<T>
    {
        List<T> MyList { get; }
        int X { get; set; }
        int Y { get; set; }
    }
    public class MyClass : IMyInterface<MyClass>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<MyClass> MyList { get; }
    }
    
