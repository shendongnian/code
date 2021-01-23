    public class BaseClass
    {
        private BaseClass _Parent;
        public virtual decimal Result
        {
            get { return ((_Parent != null) ? _Parent.Result : -1); }
        }
    }
    public class DerivedClass : BaseClass
    {
        private decimal _Result;
        public new decimal Result
        {
            get { return _Result; }
            set { _Result = value;  }
        }
    }
