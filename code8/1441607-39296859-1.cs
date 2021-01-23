    public static Expression<Func<CustomTable123, MyClass>> TranslateExp = 
      x => new MyClass
      {
        propertyA = x.Table1.Key,
        ...
      } 
    }
      
