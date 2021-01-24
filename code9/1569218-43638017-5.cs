    public static ObjectOut Method1(Object1 obj1)
    {
         return Method(obj1.ErrorCode);
    }
    public static ObjectOut Method2(Object2 obj1)
    {
         return Method(obj2.ErrorCode);
    }
    public static ObjectOut Method(int errorCode)
    {
         if (errorCode == 0)
         {
             ...
         }
    }
