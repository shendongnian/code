    // note that we return the task here
    private async Task BindSomething(int millSecToWait)
    {
        // use Task.Run in this case
        var someTask = Task.Run(() =>
            {
                // Some work
                System.Threading.Thread.Sleep(millSecToWait);
                // return some list for binding
                return new List<int>();
            });
    
        DataBindingTasks.Add(someTask);
    
        // wait until data has loaded
        var listToBind = await someTask;
    
        // bind the data to a grid
    }
    // async void for the event handler
    private async void Load()
    {
        // start tasks in fire-and-forget fashion
        BindSomething(5000);
        BindSomething(8000);
        BindSomething(2000);
    
        // code to execute when all data binding tasks have completed
        await Task.WhenAll(DataBindingTasks);
        // Do something after all binding is complete
    }
