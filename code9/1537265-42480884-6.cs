    public interface IMultipleDbResult<T, TCollection>
           where TCollection : ICollection<T>
    {
         TCollection Items { get; }
         int TotalRowCount { get; }
    }
    
    public interface ISingleDbResult<T>
    {
          T Item { get; }
    }
