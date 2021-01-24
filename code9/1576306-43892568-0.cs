    public class Base1
    {
    }
    public class Derived1 : Base1
    {
    }
    public class Base2
    {
        public virtual Base1 Method()
        {
            return new Base1();
        }
    }
    public class Derived2 : Base2
    {
        public override Base1 Method()
        {
            return new Derived1();
        }
    }
