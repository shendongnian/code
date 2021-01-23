    public static void GetNullableInt32(this DbDataReader reader, string propName)
    {
       //...
    }
    
    //calling method
    myClassInstance.MyInt = reader.GetNullableInt32(nameof(MyClass.MyInt));
