    public interface IMyClass
    {
        // All members of MyClass
    }
    public class MyClassV1 : V1.MyClass, IMyClass
    {
        // No need to re-implement members (base class satisfies interface)
    }
    public class MyClassV2 : V2.MyClass, IMyClass
    {
        // No need to re-implement members (base class satisfies interface)
    }
