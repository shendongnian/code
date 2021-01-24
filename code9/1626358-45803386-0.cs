    public class FooImpl : IFoo
    {
        private BarImpl _barImpl;
        public BarImpl Bar
        {
            get { return _barImpl; }
            set { _barImpl = value; }
        }
        IBar IFoo.Bar
        {
            get { return _barImpl; }
            set { _barImpl = (BarImpl)value; }
        }
    }
