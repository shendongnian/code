    public interface IA
    {
       void FunctionA(); 
    }
    public interface IB
    {
       void FunctionB();
    }
    public class A : IA
    {
        // actual code
    }
    public class B : IB
    {
        // actual code
    }
    
    public class Derived : IA, IB
    {
        private IA _a;
        private IB _b;
        public Derived(IA a, IB b)
        {
            _a = a;
            _b = b;
        }
        public void FunctionA()
        {
            _a.FunctionA();
        }
        public void FunctionB()
        {
            _b.FunctionB();
        }
    }
