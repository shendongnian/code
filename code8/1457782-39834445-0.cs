    public class MyFixture
    {
        [Test, Order(1)]
        public void TestA() { ... }
    
    
        [Test, Order(2)]
        public void TestB() { ... }
    
        [Test]
        public void TestC() { ... }
    }
