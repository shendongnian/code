    public static void CreateFile<T>(this List<T> lines)
    {
        List<string> mylist = new List<string>();
        var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        foreach (var item in lines)
        {
            foreach (var prop in props)
            {
                var val = prop.GetValue(item);
                // do what you want with val, you can call ToString() on it
            }
        }
    }
