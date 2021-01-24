    public static void Main(string[] args)
    {
        string Class = "Example.OtherClass";
        string[] Parameters = { "User", "123", "IE" };
        Type type = Type.GetType(Class);
        Object obj = Activator.CreateInstance(type);
        MethodInfo methodInfo = type.GetMethod("MyFunction");
        methodInfo.Invoke(obj, new[] { Parameters })
    }
