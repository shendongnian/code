    var allParams = new List<string>(); // supposingly has 10 items inside it
    var secondCollection = new List<string>(); // collection of 100
    var queue = new ConcurrentQueue<string>(secondCollection); //Copy of 100
    while (queue.Count > 0)
    {
        Parallel.ForEach(allParams, new ParallelOptions { MaxDegreeOfParallelism = 10 }, 
        (param) =>
        {
            string item;
            bool ok = queue.TryDequeue(out item);
            if (ok)
            {
                callingSomeMethod(param, item);
            }
        });
    }
