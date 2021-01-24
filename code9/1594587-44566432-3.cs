    public interface ISomethingDatabase
    {
        IQueryable<User> Users { get; }
        IQueryable<Customer> Customers { get; }
        ...
    }
