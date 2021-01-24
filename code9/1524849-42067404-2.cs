    public abstract class BaseClass
    {
        public string SomeInfo { get; set; }
    }
    
    public class DerivedClass1 : BaseClass
    {
        public DerivedClass1()
        {
            base.SomeInfo = "ChildInfo1";
        }
        public new string SomeInfo => base.SomeInfo;
    }
