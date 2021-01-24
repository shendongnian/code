    public DrawGraph(string Name)
    {
        var task = new Task(() => timeConsumingProcess(Name));
        task.Start();
        task.ContinueWith(t => {
            ...
        });
    }
