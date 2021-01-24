    public void Something()
    {
         var task = new Task(() => DoWork());
         task.ContinueWith(() => MoreWorkAfter());
         task.Start();
    }
    
    //Is the same as
    
    public async void Something()
    {
         var task = new Task(() => DoWork());
         task.Start();
         await Task;
         MoreWorkAfter();
    }
    //Is also the same as 
    public async void Something()
    {
         var task = Task.Run(() => DoWork());
         await Task;
         MoreWorkAfter();
    }
    //Still the same as 
    public async void Something()
    {
         await Task.Run(() => DoWork());
         MoreWorkAfter();
    }
