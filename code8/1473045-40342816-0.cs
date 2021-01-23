    public class AsyncTaskRunner
    {
      public static AsyncLazy<string> TaskToComplete { get; } =
          new AsyncLazy<string>(() => GetDataAsync());
      private static async Task<string> GetDataAsync()
      {
        ...
      }
    }
