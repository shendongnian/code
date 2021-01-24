    public interface ISearchResult<out T>
    {
         public int RedultCount { get; }
         public IEnumreable<T> Result { get; }
    }
