    public class Base
    {
        protected void Method1 { /*...*/ }
    }
    public class Class1 : Base
    {
        public void Method2 { Method1(); }
    }
