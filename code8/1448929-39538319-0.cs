       [TestFixture("setup1", 5)]
       [TestFixture("setup2", 9)]
       public class MyTestFixture
       {
          public MyTestFixture(string setup, int counter)
          {
             // You can save the arguments, or do something 
             // with them and save the result in instance members
          }
    
          [Test]
          public void SomeTest()
          {
             // Do what you need to do, using the arguments
          }
       }
