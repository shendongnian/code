    byte[] file = Properties.Resources.ExeName;
    Assembly assembly = Assembly.Load(file);
    // search for the Entry Point
    MethodInfo method = assembly.EntryPoint;
    if (method != null)
    {
        // Get the type that implements the EntryPoint method
        var implementingType = method.DeclaringType;
        // Call the EntryPoint method, passing in an empty array of strings as its parameters
        method.Invoke(implementingType, new object[] { new string[] { } });
    }
