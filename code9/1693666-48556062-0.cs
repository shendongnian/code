    public static async Task MyMethod()
    {
        var sw = new Stopwatch();
        sw.Start();
        await doWorkAsync();
        var task1TookTime = sw.Elapsed;
        Console.WriteLine($"Task 1 took {task1TookTime}");
        //Some other work of this child task
    }
