    public interface IRepository<T, U>
    where T : IEnumerable<U>
    {
        // Database
        T Budgets { get; set; }
    }
