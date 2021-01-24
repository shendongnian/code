    public static bool IsNullOrEmpty(this Array array)
        {
            // This is an extension of an existing function
            // to make it work with arrays.
            return (array == null || array.Length == 0);
        }
