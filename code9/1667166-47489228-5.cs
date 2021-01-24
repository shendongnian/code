    internal class Program
    {
        private static void Main()
        {
            var ab = A.Create<B.Creator>();
            ab.Foo();
    
            var ac = A.Create<C.Creator>();
            ac.Foo();
        }
    }
    
    public abstract class A
    {
        public virtual void Foo() => Console.WriteLine("A");
    
        public static A Create<T>()
            where T : ICreator, new()
        {
            return new T().Create();
        }
    }
    
    public interface ICreator
    {
        A Create();
    }
    
    public class B : A
    {
        private B() => Console.WriteLine("B.ctor()");
        public override void Foo() => Console.WriteLine("B");
    
        public class Creator : ICreator
        {
            public virtual A Create() => new B();
        }
    }
    
    public class C : A
    {
        private C() => Console.WriteLine("C.ctor()");
        public override void Foo() => Console.WriteLine("C");
    
        public class Creator : ICreator
        {
            public virtual A Create() => new C();
        }
    }
