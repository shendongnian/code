    public class A {
    };
    public class B:A
    {
        public B(int y){ x = y; }
        public int x { get; }
    }
    public class C
    {
        public static T validate<T>(int index, Func<int, T> instantiator)
           where T : A
        {
            if (false)
                return null;
            return instantiator(index);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = C.validate<B>(42, (y)=>new B(y));
        }
    }
