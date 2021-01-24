    static void Main(string[] args)
    {
        Console.WriteLine("Start");
        List<Task<string>> tasks = new List<Task<string>>();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        tasks.Add(Task.Run(() => ProcessExec.Start("hostname")));
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        tasks.Add(Task.Run(() => ProcessExec.Start("ipconfig")));
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        tasks.Add(Task.Run(() => ProcessExec.Start("date")));
        Task.WaitAll(tasks);
        sw.Stop();
        Console.WriteLine(sw.Elapsed.TotalSeconds);
        Console.WriteLine(string.Join(Environment.NewLine,
            tasks.Select((t, i) => $"{i + 1} - {t.Result}")));
        Console.WriteLine("End");
        Console.ReadKey();
    }
