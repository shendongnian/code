    public abstract class TheEnforcer<T> where T: TestClass, IMyInterface
        {
            protected abstract T GetClassInstance();
        }
    
        public class ThePoorClass : TheEnforcer<DerivedTestClass>
        {
            protected override DerivedTestClass GetClassInstance()
            {
                throw new NotImplementedException();
            }
        }
    
        public class TestClass
        {
    
        }
    
        public class DerivedTestClass : TestClass, IMyInterface
        {
    
        }
    
        public interface IMyInterface
        {
    
        }
