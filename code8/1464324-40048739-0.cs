    // The sealed class within another library
    public sealed ThirdPartyClass
    {
        public ThirdPartyClass(int i) { }
        public int SomeProperty { get; set; }
        public int SomeMethod(string val) { return 0; }
        public static void SomeStaticMethod() { }
    }
    // The wrapper class to use as a pseudo base class for ThirdPartyClass
    public class BaseClass
    {
        private ThirdPartyClass _obj;
        public BaseClass(int i) { _obj = new ThirdPartyClass(i); }
        public int SomeProperty
        {
            get { return _obj.SomeProperty; }
            set { _obj.SomeProperty = value; }
        }
        public int SomeMethod(string val) { return _obj.SomeMethod(val); }
        public static SomeStaticMethod() { ThirdPartyClass.SomeStaticMethod(); }
    }
    // The child class that inherits from the "base" BaseClass
    public class ChildClass : BaseClass
    {
        
    }
