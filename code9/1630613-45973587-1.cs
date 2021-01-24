    public async Task Execute(IEnumerable<Func<Task>> actions, Action catchAction)
    {
        try
        {
            foreach (var action in actions)
            {
                await action();
            }
        }
        catch (Exception ex)
        {
            catchAction()
        }
    }
