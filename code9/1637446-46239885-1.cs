    public static class AsyncTupleHelpers
    {
      public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> task1, Task<T2> task2) =>
          (await task1.ConfigureAwait(false), await task2.ConfigureAwait(false));
      public static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(Task<T1> task1, Task<T2> task2, Task<T3> task3) =>
          (await task1.ConfigureAwait(false), await task2.ConfigureAwait(false), await task3.ConfigureAwait(false));
      /* More if you want, following the same pattern */
    }
