    Task.Factory.StartNew(() =>
        Parallel.For(0, X, i =>
        {
            foreach (IProgress p in queue.GetConsumingEnumerable(source.Token))
            {
                MyFunction(p);
            }
        }), source.Token);
