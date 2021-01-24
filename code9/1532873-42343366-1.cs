    public class SpecializedType : OtherBaseClass<ISpecialized>, ISpecialized
    {
        // foreign implementation
    }
    public abstract class BaseClass<TBase> : ISomeInterface
        where TBase : OtherBaseClass<ISpecialized>
    {
        protected TBase BaseObject = null;
    
        protected abstract TBase CreateObject();
    
        public void Initialize()
        {
            BaseObject = CreateObject();
        }
    
        public void DoSomethingGeneric()
        {
            BaseObject.GenericMethod();
        }
    }
    
    public class DerivedClass : SpecializedType 
    {
        protected DerivedClass  CreateObject()
        {
            return new DerivedClass();
        }
    
        public void DoSomething()
        {
            DerivedObjectAccessor.SpecializedMethodNotInBaseType();
        }
    }
