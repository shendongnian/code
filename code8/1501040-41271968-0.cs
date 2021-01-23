    public class SomeClass
    {
      private SomeClass()
      {
      }
      public static SomeClass GetInstance()
      {
        // Throw Exception here, not in constructor
      }
      public void SomeFunctionThatCanFail()
      {
      }
    }
