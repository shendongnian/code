    static ConcurrentQueue<CommandDetail> _commandDetails = new ConcurrentQueue<CommandDetail>();
    
    static void Main(string[] args)
    {
        Task task1 = Task.Factory.StartNew(() => doStuff(_commandDetails));
        Task task2 = Task.Factory.StartNew(() => doStuff(_commandDetails));
        Task task3 = Task.Factory.StartNew(() => doStuff(_commandDetails));
        var _timer = new System.Threading.Timer(new TimerCallback(JobCallBack), null, 0, 1000);
        Console.ReadLine();
    }
    
    private static void JobCallBack(object state)
    {
        const int chunk = 100;
        if (_commandDetails.Count >= chunk)
        {
            var items = _commandDetails.Take(chunk);
            Remove(_commandDetails, chunk);
            Console.WriteLine($"DB call with {chunk} Items");
        }
    }
    
    private static void Remove(ConcurrentQueue<CommandDetail> q, int count)
    {
        CommandDetail commandDetail;
        Enumerable.Range(1, count).ToList().ForEach(n => q.TryDequeue(out commandDetail));
    }
    static void doStuff(ConcurrentQueue<CommandDetail> typed)
    {
        var cst = new CommandDetail();
        for (int i = 0; i < 300; i++)
        {
            Thread.Sleep(300);
            typed.Enqueue(cst);                
        }
    }
