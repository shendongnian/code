    public abstract class ClassZero
    {
        public abstract string GetTargetName();
    }
    public class ClassA : ClassZero
    {
        public override string GetTargetName()
        { 
            return DoSomething();
        }
    }
    
    public class ClassB : ClassZero
    {
        public override string GetTargetName()
        { 
            return DoSomethingElse();
        }
    }
