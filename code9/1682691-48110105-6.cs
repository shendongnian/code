    public interface IFetchLinesWorker<out T, U>
    {
        List<U> Result { get; }
        ...
    }
    public class FetchLinesWorker<T, U> : IFetchLinesWorker<T, U>
    {
        ...
    }
