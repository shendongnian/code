    private static void GetProperties(Type classType)
    {
        foreach (PropertyInfo property in classType.GetProperties(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
        {
            // other code omitted...
