    static void Main(string[] args)
    {
        // change to the recommended Task.Run method
        var task = Task.Run(() => GetSite()); 
        task.GetAwaiter().GetResult(); // block until the Task is finished
        ReadLine(); 
    }
