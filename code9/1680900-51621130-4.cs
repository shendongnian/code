    public static async Task<TResult> Cast<TSource, TResult>([NotNull] this Task<TSource> task, Type<TResult> type = null)
    {
        return (TResult)(object) await task.ConfigureAwait(false);
    }
    // Dummy type class
    public class Type<T>
    {
    }
    public static class TypeExtension
    {
        public static Type<T> ToGeneric<T>(this T source)
        {
            return new Type<T>();
        }
    }
