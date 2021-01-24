    public interface A { }
    public struct B :A { }
    public struct C :A { }
    public struct D: A { }
    public class MyClass
    {
        int counter;
        private void DoSomething(B b) { new NotImplementedException(); }
        private void DoSomething(C c) { new NotImplementedException(); }
        private void DoSomething(D d) { new NotImplementedException(); }
        public void DoSomethingExternal(A arg)
        {
            if (arg is B)
            {
                DoSomething((B)arg);
            }
            else if (arg is C)
            {
                DoSomething((C)arg);
            }
            else if (arg is D)
            {
                DoSomething((D)arg);
            }
            else
            {
                // If `A` is not of `B`, `C` or `D` types return without incrementing counter
                return;
            }
            counter++;
        }
    }
