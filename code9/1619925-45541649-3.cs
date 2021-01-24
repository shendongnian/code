    public abstract class Base<T>
    {
        public T MyAwesomeProperty { get; private set; }
        public void Test(Func<T, object> func)
        {
            func(MyAwesomeProperty);
        }
    }
