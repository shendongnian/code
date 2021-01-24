    public class DbResultSet<T, TCollection> : IDbResultSet<T, TCollection>
           where TCollection : ICollection<T> 
    {
        public TCollection  Items { get; private set; }
        public int TotalRowCount { get; private set; }
    
        public DbResultSet(TCollection items, int totalRowCount)
        {
            // Note that qualifying with "this" is redundant here
            // so I've removed it
            Items = items;
            TotalRowCount = totalRowCount;
        }
    }
