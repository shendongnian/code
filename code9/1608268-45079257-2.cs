    public static class ObjectExtensionMethods
    {
        public static IQueryable<TEntityType> ToQueryable<TEntityType>(this TEntityType instance)
        {
            return new [] {instance}.AsQueryable();
        }
    }
