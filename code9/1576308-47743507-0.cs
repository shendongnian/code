    public class Base1
    {
    }
    
    public class Derived1 : Base1
    {
    }
    
    public interface Base2<out T> where T : Base1
    {
        T Method();
    }
    
    public class Derived2 : Base2<Derived1>
    {
        public Derived1 Method()
        {
            return new Derived1();
        }
    }
