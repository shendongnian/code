    public class ExampleBase
    {
        //....
    }
    public class ExampleBase<T> : ExampleBase where T: GenericType
    {
        public T Foo
        {
            get;
            set;
        }
    }
