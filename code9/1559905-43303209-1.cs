    private Task DoWorkAsync()
    {
        Debug.WriteLine("Still on main thread")
        var task = new Task(() =>
        {
            Debug.WriteLine("On background thread");
        });
        task.Start(); //On main thread.
        return task; //On main thread.
    }
    
    private async void Method()
    {
         Debug.WriteLine("On main thread");
         await DoWorkAsync(); //returns to caller after DoWorkAsync returns Task
         Debug.WriteLine("Back on main thread"); //Works here after the task DoWorkAsync returned is complete
    }
