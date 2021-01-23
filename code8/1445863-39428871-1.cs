    public static MyMain CreateClass(MyEnum value)
    {
        var targetType = Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .Where(t => t.IsSubclassOf(typeof(MyMain)) &&
                                        t.GetCustomAttribute<MyAttribute>()?.Value == value)
                                 .FirstOrDefault();
        if (targetType != null)
            return Activator.CreateInstance(targetType) as MyMain;
        return null;
    }
