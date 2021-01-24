    static void Main(string[] args)
    {
        Task.WaitAll(Enumerable.Range(0, 1000).Select(o => doTask()).ToArray());
        Console.WriteLine("1");
        Task.WaitAll(Enumerable.Range(0, 1000).Select(o => doTask2()).ToArray());
        Console.WriteLine("2");
    }
    public async static Task doTask() => await Task.Delay(TimeSpan.FromSeconds(1));
    public async static Task doTask2() => await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(1)));
