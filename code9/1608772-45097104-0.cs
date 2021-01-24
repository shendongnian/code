     namespace NUnitTestAbstract
        {
            public interface IBaseTes1
            {
                void BaseTestClass1Method();
            }
    
            public abstract class BaseTestClass2 : IBaseTes1
            {
                void IBaseTes1.BaseTestClass1Method()
                {
                    
                }
                
                // not overriding BaseTestClass1Method, child classes should do
                public void SomeTestMethodA() { }
    
                public void SomeTestMethodB() { }
            }
    
            public class TestClassA : BaseTestClass2
            {
            }
    
            public class TestClassb : BaseTestClass2
            {
            }
        }
