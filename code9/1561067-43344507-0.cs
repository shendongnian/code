    public class A {
        public A()
        {
           BClass = new B();
           CClass = new C();
        }
        public B BClass;
        public C CClass;
    }
    public class B { 
        ..props
    }
    public class C { 
        ..props
    }
