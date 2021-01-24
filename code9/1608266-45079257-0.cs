    public static class ObjectExtensionMethods
    {
        public static IQueryable<TEntityType> ToQueryable<TEntityType>(this TEntityType instance)
        {
            TEntityType[] arrayOfObject = {instance};
            return arrayOfObject.AsQueryable();
        }
    }
