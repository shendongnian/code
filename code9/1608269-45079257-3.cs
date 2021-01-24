    public static class ObjectExtensionMethods
    {
        public static IQueryable<T> ToQueryable<T>(this T instance)
        {
            return new [] {instance}.AsQueryable();
        }
    }
