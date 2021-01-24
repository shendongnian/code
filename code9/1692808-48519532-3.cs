    private static Dictionary<MyEnum, Type> _myEnumDictionary = new Dictionary<MyEnum, Type>();
    public MyBaseClass GetEnumClass(MyEnum enumType)
    {
        if (!_myEnumDictionary.ContainsKey(enumType))
        {
            var enumClass = typeof(MySubClass).Assembly
                .GetTypes()
                .FirstOrDefault(x => x.GetCustomAttributes<MyCustomAttribute>()
                    .Any(k => k.EnumType == enumType));
            if (enumClass == null)
            {
                throw new Exception("There is no declared class with the enumType" + enumType);
            }
            _myEnumDictionary.Add(enumType, enumClass);
        }
        return (MyBaseClass)Activator.CreateInstance(_myEnumDictionary[enumType]);
    }
