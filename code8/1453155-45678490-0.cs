    public class B
    { }
    public class Bext : B
    { }
    public class A
    {
        public virtual B Details { get; set; }
        public A()
        {
            Details = new B();
        }
    }
    public class Aext : A
    {
        public override B Details => new Bext();
    }
