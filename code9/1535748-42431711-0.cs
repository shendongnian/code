    public interface IFoo
    {
        void Foo();
        void Bar();
    }
    public abstract class BaseFoo : IFoo
    {
        public virtual void Foo()
        {
            //do nothing
        }
        public virtual void Bar()
        {
            //do nothing
        }
    }
    public class A : BaseFoo //replace with IFoo if you do not want the base class, in that case implement both methods
    {
        IList<B> Bs { get; set; }
        IList<C> Cs { get; set; }
        public override void Bar()
        {
            base.Bar();
            foreach (var b in Bs)
            {
                b.Bar();
            }
            foreach (var c in Cs)
            {
                c.Bar();
            }
        }
    }
    public class B : BaseFoo //replace with IFoo if you do not want the base class, in that case implement both methods
    {
        IList<D> Ds { get; set; }
        public override void Bar()
        {
            base.Bar();
            foreach (var d in Ds)
            {
                d.Bar();
            }
        }
    }
    public class C : BaseFoo //replace with IFoo if you do not want the base class, in that case implement both methods
    {
        
    }
    public class D : BaseFoo //replace with IFoo if you do not want the base class, in that case implement both methods
    {
        
    }
    public static class Helper
    {
        public static void Bar(params IFoo[] foos)
        {
            foreach (var foo in foos)
            {
                foo.Bar();
            }
        }
    }
