    public class A
    {
        public static explicit operator B(A a)
        {
            return new B();
        }
    }
    public class B { }
    public class Convert
    {
        public static T To<T>(dynamic obj)
        {
            return (T) obj;
        }
    }
    class Foo
    {
        private List<A> content = new List<A>();
        public void AddRange<T>(IEnumerable<T> iterable) where T : B
        {
            foreach (T t in iterable)
                content.Add(Convert.To<A>(t)); // This will invoke the implicit operator defined in A
        }
    }
