    public interface IFoo<T> where T : IBar
    {
        T Bar { get; set; }
    }
    public class FooImpl : IFoo<BarImpl>
    {
        private BarImpl _barImpl;
        public BarImpl Bar
        {
            get { return _barImpl; }
            set { _barImpl = value; }
        }
    }
