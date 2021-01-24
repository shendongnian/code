    public abstract class BaseClass
    {
        protected string _someInfo;
        public string SomeInfo
        {
            get { return _someInfo; }
            set { _someInfo = value; }
        }
    }
    
    public class DerivedClass1 : BaseClass
    {
        public DerivedClass1()
        {
            _someInfo = "ChildInfo1";
        }
        public new string SomeInfo
        {
            get { return _someInfo; }
        }
    }
