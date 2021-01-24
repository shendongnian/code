    public static void MethodEntry<T>(string methodName, params object[] parameters)
    {
        Log.ForContext<T>()
            .ForContext("Parameters", parameters)
            .Debug("Entering {MethodName}", methodName);
    }
