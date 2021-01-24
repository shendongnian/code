    public class ComponentA
    {
        private ClassName b;
        public ComponentA(ClassName b)
        {
            this.b = b;
        }
        public void DoSomething()
        {
            // Do something with instance B
        }
    }
    // Test class
    public Class ATest
    {
        [test]
        public void TestMethod()
        {
            // Arrange
            B b = new FakeB();
            
            var a = new ComponentA(b);
            
            // Act
            a.DoSomething();
            
            // Assert
            // Check whether be was invoked correctly.
        }
    }
