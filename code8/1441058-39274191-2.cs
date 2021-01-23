    public static async Task<T> ThrowIfNullAsync<T>(this Task<T> task, string message) 
    where T : class
    {
        var obj = await task;
        if (obj == null)
            throw new HttpException(404, string.Format(Resources.GenericNotFound, message));
        return obj;
    }
