    public static void CallMethod<T>(string methodName, string value)
    {
        var method = typeof(T).GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);
        if (method == null)
        {
            Console.WriteLine("The method not found");
            return;
        }
        foreach (var myAttribute in method.GetCustomAttributes(typeof(MyCustomAttribute)).OfType<MyCustomAttribute>())
        {
            if (myAttribute.SomeProperty == value)
            {
                method.Invoke(null, null);
            }
            else
            {
                Console.WriteLine("The attribute parameter is not as required");
            }
        }
    }
