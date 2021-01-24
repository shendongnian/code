    public interface IMyClass
    {
        // All members of MyClass 
        // (except we have a special case for DoSomething() because it
        // has a return type SomeType we also need to adapt to ISomeType).
        ISomeType DoSomething();
    }
    public class MyClassV1 : V1.MyClass, IMyClass
    {
        // No need to re-implement members (base class satisfies interface)
        // However, if there are return parameters, you will need to 
        // also use a decorator pattern to wrap them in another adapter.
        public ISomeType DoSomething()
        {
            return new SomeTypeV1(base.DoSomething());
        }
 
    }
    public class MyClassV2 : V2.MyClass, IMyClass
    {
    }
    public interface ISomeType
    {
         // All members of SomeType
    }
    public class SomeTypeV1 : ISomeType
    {
        private readonly SomeType someType;
 
        public SomeType(SomeType someType)
        {
            this.someType = someType;
        }
        // re-implement all members and cascade the call to someType
    }
