    namespace First {
        public abstract class TheEnforcer<T> where T : IMarkerInterface
        {
            protected abstract T GetClassInstance();
        }    
    
        public interface IMarkerInterface
        {
    
        } }
    
    namespace Second {
        using First;
    
        // All this is in separate name space
        public class TestClass: IMarkerInterface
        {
    
        }
    
        public class DerivedTestClass : TestClass, IMyInterface
        {
    
        }
    
        public interface IMyInterface
        {
    
        }
    
        public class ThePoorClass : TheEnforcer<DerivedTestClass>
        {
            protected override DerivedTestClass GetClassInstance()
            {
                throw new NotImplementedException();
            }
        } }
