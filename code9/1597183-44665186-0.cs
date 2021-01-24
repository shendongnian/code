    public interface IRepository<T>
    where T : IEnumerable<Budget>
    {
        // Database
        T Budgets { get; set; }
    }
