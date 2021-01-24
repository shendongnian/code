    public enum MyEnum{
      A = 1,
      B = 2,
      C = 3
    }
    
    public enum MyOtherEnum{
      D = 1,
      E = 2,
      F = 3
    }
    string str = "A";
    MyEnum yourEnum = str.ToEnum<MyEnum>();
    
    string str2 = "A";
    MyOtherEnum yourOtherEnum = str.ToEnum<MyOtherEnum>();
