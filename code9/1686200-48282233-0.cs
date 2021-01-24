    var set = new SortedSet<Token>();
    var locker = new object();
    var tokens = bazTokens
        .Merge(barTokens)
        .Merge(fooTokens)
        .Do(dt => Display(dt, ConsoleColor.Red));
    tokens.Subscribe(dt =>
    {
        lock (locker)
        {
            set.Add(dt);
        }
    });
    for (var i = 0; i < Environment.ProcessorCount; i++)
    {
        Task.Run(() =>
        {
            while (!source.IsCancellationRequested)
            {
                Token dt;
                lock (locker)
                {
                    dt = set.FirstOrDefault();
                }
                if (dt == null)
                {
                    continue;
                }
                bool removed;
                lock (locker)
                {
                    removed = set.Remove(dt);
                }
                if (removed)
                {
                    Display(dt, ConsoleColor.Green, 750);
                }
            }
        }, source.Token);
    }
