    public interface ISearchResult<out T>
    {
         public int ResultCount { get; }
         public IEnumerable<T> Result { get; }
    }
