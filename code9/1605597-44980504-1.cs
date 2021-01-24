    class Test 
    {
      public static bool IsValid(int value) 
      {
         return whatever; // test for validity here
      }
      private int value;
      public int Value { get { return value; } 
        set 
        {
          if (!IsValid(value)) throw new InvalidArgumentException("value");
          this.value = value;
        }
      }
      public Test(int value) {
        this.Value = value;
      }
    }
