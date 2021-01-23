    // The <T> is to make T a generic type
    public static void ResetArray<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // default(T) will return the default value for whatever type T is
                // For example, if T is an int, default(T) would return 0
                array[i] = default(T);
            }
        }
