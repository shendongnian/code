    namespace NUnitTestAbstract
    {
        public interface BaseTestClass1
        {
            void BaseTestClass1Method();
        }
        public abstract class BaseTestClass2
        {
            private BaseTestClass1 _baseTestClass1Implementation;
            public BaseTestClass2(BaseTestClass1 baseTestClass1Implementation)
            {
                _baseTestClass1Implementation = baseTestClass1Implementation;
            } 
            public void BaseTestClass1Method()
            {
                _baseTestClass1Implementation.BaseTestClass1Method();
            }
            // not overriding BaseTestClass1Method, child classes should do
            public void SomeTestMethodA() { }
     
            public void SomeTestMethodB() { }
        }
        public abstract class BaseTestClass3
        {
            private BaseTestClass1 _baseTestClass1Implementation;
    
            public BaseTestClass3(BaseTestClass1 baseTestClass1Implementation)
            {
                _baseTestClass1Implementation = baseTestClass1Implementation;
            }
    
            public void BaseTestClass1Method()
            {
                _baseTestClass1Implementation.BaseTestClass1Method();
            }
    
            // not overriding BaseTestClass1Method, child classes should do
            public void SomeTestMethodX() { }
    
            public void SomeTestMethodY() { }
        }
    
        public class TestClass2A : BaseTestClass2
        {
            public void SomeMethodThatUsesBaseTestClass1Method()
            {
                BaseTestClass1Method();
            }
        }
    
        public class TestClass2B : BaseTestClass2
        {
            public void SomeMethodThatUsesBaseTestClass1Method()
            {
                BaseTestClass1Method();
            }
        }
    
    
        public class TestClass3A : BaseTestClass3
        {
            public void SomeMethodThatUsesBaseTestClass1Method()
            {
                BaseTestClass1Method();
            }
        }
    
        public class TestClass3B : BaseTestClass3
        {
            public void SomeMethodThatUsesBaseTestClass1Method()
            {
                BaseTestClass1Method();
            }
        }
    }
    public class BaseTestClass1Implementation1 : BaseTestClass1
    {
        public void BaseTestClass1Method()
        {
          //do something
        }
    }
    
    public class BaseTestClass1Implementation2 : BaseTestClass1
    {
        public void BaseTestClass1Method()
        {
          //do something
        }
    }
    
    var testClass2A = new TestClass2A(new BaseTestClass1Implementation1())
    var testClass2B = new TestClass2B(new BaseTestClass1Implementation1())
    
    var testClass3A = new TestClass3A(new BaseTestClass1Implementation2())
    var testClass3B = new TestClass3B(new BaseTestClass1Implementation2())
    
    testClass2A.SomeMethodThatUsesBaseTestClass1Method();
    testClass2B.SomeMethodThatUsesBaseTestClass1Method();
    
    testClass3A.SomeMethodThatUsesBaseTestClass1Method();
    testClass3B.SomeMethodThatUsesBaseTestClass1Method();
