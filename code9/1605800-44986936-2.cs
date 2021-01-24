    public static class ArrayExtensions
    {
        public static void Deconstruct<T>(this T[] values, out T item1, out T item2, out T item3)
        {
            item1 = values[0];
            item2 = values[1];
            item3 = values[2];
        }
    }
