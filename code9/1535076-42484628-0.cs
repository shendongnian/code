    namespace Tests
    {
      using Xunit;
    
      using XunitSample;
    
      public class Class1
      {
        [Fact]
        public void Example1_Test()
        {
          var ex2 = (Example2)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Example2));
    
          var target = new Example1(ex2);
    
          Assert.NotNull(target);
        }
      }
    }
