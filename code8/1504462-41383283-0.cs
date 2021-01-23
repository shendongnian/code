    public static void GetNullableInt32(this DbDataReader reader, string propName)
    {
       //...
    }
    
    myClassInstance.MyInt = reader.GetNullableInt32(nameof(MyClass.MyInt));
