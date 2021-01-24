    internal class Program
    {
        private static void Main()
        {
            var ab = A.Create<B>();
            ab.Foo();
    
            var ac = A.Create<C>();
            ac.Foo();
        }
    }
    
    public abstract class A
    {
        public virtual void Foo() => Console.WriteLine("A");
    
        public static A Create<T>()
            where T : A
        {
            return Factories[typeof(T)]();
        }
    
        private static readonly Dictionary<Type, Func<A>> Factories;
        static A()
        {
            Factories = new Dictionary<Type, Func<A>>();
            B.AppendFactory(Factories);
            C.AppendFactory(Factories);
        }
    }
    
    public class B : A
    {
        private B() => Console.WriteLine("B.ctor()");
        public override void Foo() => Console.WriteLine("B");
    
        public static void AppendFactory(Dictionary<Type, Func<A>> factories)
        {
            factories.TryAdd(typeof(B), () => new B());
        }
    }
    
    public class C : A
    {
        private C() => Console.WriteLine("C.ctor()");
        public override void Foo() => Console.WriteLine("C");
    
        public static void AppendFactory(Dictionary<Type, Func<A>> factories)
        {
            factories.TryAdd(typeof(C), () => new C());
        }
    }
