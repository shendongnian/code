    public interface IDbResultSet<T, TCollection>
           where TCollection : ICollection<T>
    {
         TCollection Items { get; }
         int TotalRowCount { get; }
    }
