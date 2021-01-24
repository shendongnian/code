    public static void PropertyValuesAreEquals<T> (T actual, T expected)
    {
         PropertyInfo[] properties = typeof (T).GetProperties ();
         //...
    }
