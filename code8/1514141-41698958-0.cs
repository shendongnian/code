    public class TestClass
    {
      [Category("TESTING")]
      public void TestMethod()
      {
        var method = typeof(TestClass).GetRuntimeMethod(nameof(TestClass.TestMethod)), new Type[]{});
        var attribute = method.GetCustomAttribute<Category>();
      }   
    }
 
