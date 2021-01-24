    public static class Extensions
    {
        public static int IndexOfIgnoring<T> (this IEnumerable<T> collection, T indexOf, T toIgnore) =>
            collection.Where (arg => !Equals (arg, toIgnore)).ToList ().IndexOf (indexOf);
    }
