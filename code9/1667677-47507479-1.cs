    public static IQueryable<T> ApplyCustomerFilter<T>(
        this IQueryable<T> collection, 
        int[] customerIds) {
            return collection.Where("@0.Contains(outerIt.CustomerId)",
                 customerIds.Cast<int?>()); // <- note here
    }
