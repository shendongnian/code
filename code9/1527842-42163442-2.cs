    public static IQueryable<T> FilterByLogin<T>(
      this MyContextType context
      Func<IQueryable<T>> query, 
      int customerId) 
      where T : ICustomerEntity
    {
      var result = query(context)
        .Where(cu => cu.CustomerId == customerId);
      return result;
    }
