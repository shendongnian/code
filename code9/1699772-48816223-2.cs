    public interface ISearchResult<out T>
    {
         int ResultCount { get; }
         IEnumerable<T> Result { get; }
    }
