    public interface IDbResult<T, TCollection>
           where TCollection : ICollection<T>
    {
         TCollection Items { get; }
         int TotalRowCount { get; }
    }
    public class DbResult<T, TCollection> : IDbResultSet<T, TCollection>
           where TCollection : ICollection<T> 
    {
        public TCollection  Items { get; private set; }
        public int TotalRowCount { get; private set; }
    
        public DbResult(TCollection items, int totalRowCount)
        {
            // Note that qualifying with "this" is redundant here
            // so I've removed it
            Items = items;
            TotalRowCount = totalRowCount;
        }
    }
