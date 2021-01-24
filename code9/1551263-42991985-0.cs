    var tasks = Enumerable.Range(0, 50).Select(x => Task.Factory.StartNew(() =>
    {
        while (true)
        {
            // ..
            try
            {
                // ..
            }
            catch (Exception ex)
            {
                // ..
            }
        }
    })).ToArray();
    Task.WaitAl((tasks);
    // investigate exceptions here
    var faulted = tasks.Where(t => t.IsFaulted);
