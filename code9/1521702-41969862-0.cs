    public class Base
    {
        public virtual void Method(D a)
        {
            Console.WriteLine("public void Method(D a)");
        }
        public void Method(B a)
        {
            Console.WriteLine("public void Method(B a)");
        }
    }
    public class Derived : Base
    {
        public override void Method(D a)
        {
            Console.WriteLine("public override void Method(D a)");
        }
    }
    public class B { }
    public class D : B { }
