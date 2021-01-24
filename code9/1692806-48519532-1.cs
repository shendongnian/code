    public MyBaseClass GetEnumClass(MyEnum enumType)
    {
        var enumClass = typeof(MySubClass).Assembly
        .GetTypes()
        .FirstOrDefault(x => x.GetCustomAttributes<MyCustomAttribute>()
                .Any(k => k.EnumType == enumType));
        if (enumClass == null)
        {
            throw new Exception("There is no declared class with the enumType" + enumType);
        }
        return (MyBaseClass)Activator.CreateInstance(enumClass);
    }
