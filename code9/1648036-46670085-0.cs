    var queue = new BlockingCollection<string>(new ConcurrentQueue<string>());
    new Thread(() => {
        foreach (var item in queue.GetConsumingEnumerable()) {
            // do heavy stuff with item
        }
    }) {
        IsBackground = true
    }.Start();
    var w = new FileSystemWatcher();
    // other stuff
    w.Changed += (sender, args) =>
    {
        // takes no time, so overflow chance is drastically reduced
        queue.Add(args.FullPath);
    };
