    public class Foo
    {
        public Foo(object arg)
        {
            Contract.Requires<ArgumentNullException>(arg != null);
        }
        public object GetBar()
        {
            Contract.Ensures(Contract.Result<object>() != null);
            // TODO:
        }
    }
