    public static void Main(string[] args)
    {
        string classNameSpace = "Example.OtherClass";
        string[] Parameters = { "User", "123", "IE" };
        Type type = Type.GetType(classNameSpace);
        Object obj = Activator.CreateInstance(type);
        MethodInfo methodInfo = type.GetMethod("MyFunction");
        methodInfo.Invoke(null, new object[] { Parameters })
    }
