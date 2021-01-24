    class Test 
    {
      public static bool IsValid(int value) 
      {
         return whatever; // test for validity here
      }
      public int Value { get; private set; } // Don't let anyone change it.
      public Test(int value) {
        if (!IsValid(value)) throw new InvalidArgumentException("value");
        this.Value = value;
      }
    }
