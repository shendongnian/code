    public async Task Execute(IEnumerable<Func<Task>> actions, Action catchAction)
    {
        var tasks = actions.Select(action => action());
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            catchAction()
        }
    }
