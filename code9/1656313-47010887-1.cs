    public static T Fill<T>(T myClass) where T: Test
    {
        typeof(T).GetProperty("Header").GetValue(myClass); // Get the value
        return obj;
    }
