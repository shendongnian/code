    public static ObjectOut Method1(Object1 obj1)
    {
         return Method(obj1.ErrorCode == 0);
    }
    public static ObjectOut Method2(Object2 obj1)
    {
         return Method(obj2.ErrorCode == 0);
    }
    public static ObjectOut Method(bool isErrorCodeZero)
    {
         if (isErrorCodeZero)
         {
             ...
         }
    }
