    public static ObjectOut Method1(Object1 obj1)
    {
       if (obj1.ErrorCode == 0)
       {
          return DoSomething();
       }
    }
    
    public static ObjectOut Method2(Object1 obj2)
    {
       if (obj2.ErrorCode == 0)
       {
          return DoSomething();
       }
    }
    public static ObjectOut DoSomething() { ... }
