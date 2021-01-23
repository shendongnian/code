    private static async Task Promisify(IJavascriptCallback resolve, IJavascriptCallback reject, Func<Task> action)
    {
        try
        {
            if (!resolve.IsDisposed)
                await action();
            if (!resolve.IsDisposed)
                await resolve.ExecuteAsync();
        }
        catch (Exception e)
        {
            if (!reject.IsDisposed)
                await reject.ExecuteAsync(e.ToString());
        }
    }
    private static async Task Promisify<T>(IJavascriptCallback resolve, IJavascriptCallback reject, Func<Task<T>> action)
    {
        try
        {
            var result = default(T);
            if (!resolve.IsDisposed)
                result = await action();
            if (!resolve.IsDisposed)
                await resolve.ExecuteAsync(result);
        }
        catch (Exception e)
        {
            if (!reject.IsDisposed)
                await reject.ExecuteAsync(e.ToString());
        }
    }
