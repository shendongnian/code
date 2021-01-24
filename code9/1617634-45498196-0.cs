    public static void PrintAllFields1(object obj)
    {
      var nestedClassType = obj.GetType();
      var declaringClassType = nestedClassType.DeclaringType;
      if (declaringClassType != null)
      {
        var fields = declaringClassType.GetFields();
      }
    }
