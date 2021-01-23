    static void Main(string[] args)
    {
        var task = Task.Factory.StartNew(() =>
        {
            // ...
        });
        task.Wait(); // The main application thread waits here until the task returns
    }
