    public class Main
    {
        public static void main(String[] args)
        {
            var list = new List<IBaseList<Base>>();
            list.Add(new DerivedList());
        }
    }
    // note "out" here
    public interface IBaseList<out T> where T : Base {
    }
    public class BaseList<T> : IBaseList<T> where T : Base {
        
    }
    public class Base {
    }
    public class DerivedList : IBaseList<Derived> {
    }
    public class Derived : Base {
    }
