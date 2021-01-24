    public T TimeCreationOf<T>(Func<T> creator, Action<T> configure = null)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = creator.Invoke();
        configure?.Invoke(result);
        stopwatch.Stop();
        Logger.Trace("Loaded " + result.GetType().Name + " [took " + stopwatch.ElapsedMilliseconds + "ms]");
        return result;
    }
