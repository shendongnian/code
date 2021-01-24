    public static string CreateDefaultEmptyJson(Type type)
    {
        return JsonConvert.SerializeObject(RecursiveCreateInstance(type), Formatting.Indented);
    }
    public static object RecursiveCreateInstance(Type type)
    {
        object obj = null;
        ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
        if (ctor != null)
        {
            obj = ctor.Invoke(null);
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Type propType = prop.PropertyType;
                if (prop.CanWrite && propType.IsClass)
                {
                    prop.SetValue(obj, RecursiveCreateInstance(propType));
                }
            }
        }
        return obj;
    }
