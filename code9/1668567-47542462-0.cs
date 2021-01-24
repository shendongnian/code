     [TestClass]
     public class Child : Base
     {
 
     // All tests go here
     [TestMethod]
     public void TestSomething()
     { }
     public class Base
     {
       // declare variables
     
      [TestInitialize]
      public void Setup()
      {
        // Create test records
      }
      [TestCleanup]
      public void Teardown()
      {
        // Delete test records
      }
