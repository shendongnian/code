    public interface ICallMe
    {
        void Visit(A a);
        void Visit(B b);
        void Visit(C c);
    }
    public class CallMe : ICallMe
    {
        public void Visit(A c)
        {
            Console.WriteLine("A");
        }
        public void Visit(B b)
        {
            Console.WriteLine("B");
        }
        public void Visit(C a)
        {
            Console.WriteLine("C");
        }
    }
    interface Element
    {
        void accept(ICallMe visitor);
    }
    public class A : Element
    {
        public void accept(ICallMe visitor)
        {
            visitor.Visit(this);
        }
    }
    public class B : Element
    {
        public void accept(ICallMe visitor)
        {
            visitor.Visit(this);
        }
    }
    public class C : Element
    {
        public void accept(ICallMe visitor)
        {
            visitor.Visit(this);
        }
    }
