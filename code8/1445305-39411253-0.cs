    private static MethodInfo GenericWriteMethod =
        typeof(Test).GetMethod("GenericWrite", BindingFlags.NonPublic | BindingFlags.Static);
    public static void Write(MemoryStream s, object value)
    {
        GenericWriteMethod
            .MakeGenericMethod(value.GetType())
            .Invoke(null, new object[] { s, value });
    }
    private static void GenericWrite<T>(MemoryStream s, T value)
    {
        HandlerFactory.Create<T>().Write(s, value);
    }
