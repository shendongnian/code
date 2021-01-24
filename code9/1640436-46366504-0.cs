    static Dispatcher dispatcher;
    static void Main(string[] args)
    {
        dispatcher = Dispatcher.CurrentDispatcher;
        Task.Run(async () => await Test());  //.Wait();
        while (true)
        {
            Dispatcher.PushFrame(new DispatcherFrame());
        }
    }
    static async Task Test()
    {
        //var dispatcher = Dispatcher.CurrentDispatcher;
        var t = Task.Run(() =>
        {
            Console.WriteLine(dispatcher.Thread.ThreadState);
            dispatcher.Invoke(() =>
            {
                Console.WriteLine("works");
            });
        });
        await t; ;
    }
