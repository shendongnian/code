    public abstract class BaseClass
    {
        protected BaseClass() 
        {
            if (this.GetType().GetMethod("GetSomething") == null) 
                throw new InvalidOperationException("BaseClass subclasses should implement 'GetSomething' method");
        }
    }
    public class ClassOne : BaseClass {
        public int GetSomething (int a, int b, out int c) { }
    }
    
    public class ClassTwo : BaseClass {
        public int GetSomething (int a, out string b) {}
    }
