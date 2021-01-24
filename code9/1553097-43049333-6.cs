    public static async Task StartAndReturnSecondTaskAsync()
    {
        await Task.Run(() =>
        {
            return StartAndReturnSecondTask();
        });
    }
    
    public static Task StartAndReturnSecondTask()
    {
        System.Threading.Thread.Sleep(5000);
        return Task.Run(() =>
        {
            System.Threading.Thread.Sleep(10000);
        });
    }
