    public class MyClass
    {
        static readonly long _someStaticMember;
        private bool _param;
        static MyClass()
        {
            //Do Some Logic
            _someStaticMember = SomeValueCalculated;
        }
        protected MyClass(bool param)
        {
            _param = param;
        }
    }
    public class ChildClass: MyClass
    {
        public ChildClass(bool param) : base(param);
    }
    public class NotChildClass
    {
        public MyClass someObject = new MyClass(true); //Will Fail
    }
