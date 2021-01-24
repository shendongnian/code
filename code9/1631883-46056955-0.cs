    protected List<MyEnum> GetEnumSet(int flagNumber)
    {
          List<MyEnum> resultList= new List<MyEnum>();
    
          foreach (MyEnumvalue in Enum.GetValues(typeof(MyEnum)))
          {
             if (((MyEnum)flagNumber).HasFlag(value))
             {
                 resultList.Add(value);
             }
          }
    
          return resultList;
    }
