    class P
    {
        static void Main() => Console.WriteLine(A.Create<A.B>().GetType());
    }
    public abstract class A
    {
        private static Dictionary<Type, Func<A>> _factories = new Dictionary<Type, Func<A>> {
            [typeof(B)] = () => B.Create(), // Example using factory method.
            [typeof(C)] = () => new C()     // Example using constructor.
        };
        public static T Create<T>() where T : A => (T)_factories[typeof(T)]();
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
