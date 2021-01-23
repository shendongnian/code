    public Task MyTask;
    protected override void OnActivate()
    {
        base.OnActivate();
        try
        {
            MyTask = DoSomethingAsync()           
        }
        catch (Exception ex)
        {
            // …
        }
    }
