    public class FooBase 
    {
        private static List<FooBase> _instances = new List<FooBase>();
        public FooBase()
        {
            _instanves.Add(this);
        }
    }
    public class Foo: FooBase { }
