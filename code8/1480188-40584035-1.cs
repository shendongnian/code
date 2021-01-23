    void Main()
    {
      byte? reviewMonth = null;
      
      string result = reviewMonth == null 
                      ? null // Exception here, though it's not easy to tell
                      : new LookupCode<object> { Description = "Hi!" };
      
      result.Dump();
    }
    
    class LookupCode<T>
    {
      public string Description { get; set; }
    
      public static implicit operator string(LookupCode<T> code)
      {
          if (code != null) return code.Description;
    
          throw new InvalidOperationException();
      }
    }
