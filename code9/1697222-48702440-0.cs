    public static class ArrayExtensions
    {
        public static List<T> ToDynamic<T>(this T[] items)
            => new List<T>(items ?? throw new ArgumentNullException(nameof(items)));
    }
