    public async Task<dynamic> TryAsync(Func<Task<dynamic>> func) {
        try {
            var result = await func();
            return result;
        }
        catch (Exception exception) {
            // do something
        }
    }
    var result = await TryAsync(FooAsync(parameters, cancellationToken));
