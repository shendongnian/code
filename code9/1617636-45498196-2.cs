    public static void PrintAllFields(object obj)
    {
        var nestedClassType = obj.GetType();
        var declaringClassType = nestedClassType.DeclaringType;
        if (declaringClassType != null)
        {
            var fields = declaringClassType.GetFields();
        }
    }
