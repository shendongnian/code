    internal class Program
    {
        private static void Main()
        {
            var ab = A.Create(new B.BCreator());
            ab.Foo();
    
            var ac = A.Create(new C.CCreator());
            ac.Foo();
        }
    }
    
    public abstract class A
    {
        public virtual void Foo() => Console.WriteLine("A");
    
        public static A Create<T>(ICreator<T> creator) where T : A
        {
            return creator.Create();
        }
    }
    
    public interface ICreator<T>
    {
        A Create();
    }
    
    public class B : A
    {
        private B() => Console.WriteLine("B.ctor()");
        public override void Foo() => Console.WriteLine("B");
    
        public class BCreator : ICreator<B>
        {
            public virtual A Create()
            {
                return new B();
            }
        }
    }
    
    public class C : A
    {
        private C() => Console.WriteLine("C.ctor()");
        public override void Foo() => Console.WriteLine("C");
    
        public class CCreator : ICreator<C>
        {
            public virtual A Create()
            {
                return new C();
            }
        }
    }
