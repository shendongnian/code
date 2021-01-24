    public static class UsingAsync
    {
        public static async Task Do<TDisposable>(
            TDisposable disposable, 
            Func<TDisposable, Task> body)
            where TDisposable : IDisposable
        {
            try
            {
                await body(disposable);
            }
            finally
            {
                if (disposable != null)
                {
                    await Task.Run(() => disposable.Dispose());
                }
            }
        }
    }
