    public static void ThreadForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        var mres = new List<ManualResetEvent>();
        foreach (var item in items)
        {
            var mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((i) =>
            {
                action((T)i);
                mre.Set();
            }, item);
            mres.Add(mre);
        }
        mres.ForEach(mre => mre.WaitOne());
    }
