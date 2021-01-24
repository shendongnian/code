    class Test 
    {
      public bool IsValid 
      {
         get 
         {
           return whatever; // test for validity here
         } // read-only property
      }
      public int Value { get; set; }
      public Test(int value) {
        this.Value = value;
      }
    }
