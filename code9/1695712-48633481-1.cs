    public class MainClass
    {
        private readonly SubClass _subClass;
    
        // constructor not shown
        public void TestMethod()
        {
            var data = SubClassMethodACall();
    
            // ...some code
    
            var someOtherData = "";
            var moreData = _subClass.MethodB(someOtherData);
    
            // ...more code
        }
    
        protected virtual string SubClassMethodACall()
        {
            return _subClass.MethodA();
        }
    }
    
    public class SubClass
    {
    
        public string MethodA()
        {
            return null;
        }
    
        public string MethodB(string s)
        {
            return null;
        }
    }
    
    namespace Tests.Unit
    {
        public class MainClassStub : MainClass
        {
            private readonly string _returnValueForMethodA;
    
            public MainClassStub(string returnValueForMethodA)
            {
                _returnValueForMethodA = returnValueForMethodA;
            }
    
            protected override string SubClassMethodACall()
            {
                return _returnValueForMethodA;
            }
        }
    
        [TestFixture]
        public class TestClass
        {
            [Test]
            public void TestMethod()
            {
                var mainClass = new MainClassStub("this is the test value returned");
                //.. rest of test
            }
        }
    }
