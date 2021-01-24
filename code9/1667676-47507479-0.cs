    public static IQueryable<T> ApplyCustomerFilter<T>(
        this IQueryable<T> collection, 
        int?[] customerIds) { // < - note here
            return collection.Where("@0.Contains(outerIt.CustomerId)", customerIds);
    } 
