    public abstract class MyClass
    {
        public virtual void DoSomething(out IMyObject obj)
        {
            obj = new MyObject();
        }
    }
    
    public class MyChildClass : MyClass
    {
        public override void DoSomething(out IMyObject obj)
        {
            obj = new MyChildObject();
        }
        
    }
    
    public interface IMyObject
    {
    }
    
    public class MyObject : IMyObject
    {
    }
    
    public class MyChildObject : MyObject
    {
    }
