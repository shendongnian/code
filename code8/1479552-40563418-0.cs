    public async Task<dynamic> TryAsync(
        Func<dynamic, CancellationToken, Task<dynamic>> func,
        dynamic parameters, CancellationToken cancellationToken)
    {
        try
        {
            return await func(parameters, cancellationToken);
        }
        catch(Exception exception)
        {
            ..
        }
    }
    TryAsync(FooAsync, parameters, cancellationToken);
