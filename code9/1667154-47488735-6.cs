    class P
    {
        static void Main() => Console.WriteLine(A.Create<A.B>().GetType());
    }
    public abstract class A
    {
        private static Dictionary<Type, Func<A>> _factories = new Dictionary<Type, Func<A>> {
            [typeof(B)] = () => B.Create(),
            [typeof(C)] = () => new C()
        };
        public static T Create<T>() where T : A
        {
            return (T)_factories[typeof(T)]();
        }
        public class B : A
        {
            private B() { }
            internal static B Create() => new B();
        }
        public class C : A
        {
            internal C() { }
        }
    }
