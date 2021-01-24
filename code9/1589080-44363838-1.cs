    public class EntityA
    {
        public string Name { get; set; }
        public int Age { get; set; }
    
        public void DoSomething(ClassName b)
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
            
            var a = new EntityA { Name = "Bert", Age = 56 };
            
            // Act
            a.DoSomething(b);
            
            // Assert
            // Check whether be was invoked correctly.
        }
    }
