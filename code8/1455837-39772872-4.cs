    public interface ITargetNameGenerator
    {
        string GetTargetName();
    }
    public void SomeMethod(ITargetNameGenerator foo)
    {
        var targetName = "";
    
        targetName = foo.GetTargetName();
        var furtherUse = localVariable.Process(targetName);
    }
    
    
    public class ClassA : ClassZero, ITargetNameGenerator
    {
        public string GetTargetName()
        {
            return DoSomething();
        }
    }
    //etc...
