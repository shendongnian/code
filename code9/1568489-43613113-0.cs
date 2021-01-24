    IMyInterface<T> where T : IMyInterface<T>
    {
         IList<T> MyList { get; set; }
         int X { get; set; }
         int Y { get; set; }
    }
    public class MyClass: IMyInterface<MyClass>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IList<MyClass> MyList { get; set; }
    }
