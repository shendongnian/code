    List<Task> tasklist = new List<Task>();
    List<ListViewItem> lit = new List<ListViewItem>();
    int maximalethreads = 3;
    this.Invoke(new Action(() =>
    {
        foreach (ListViewItem itt in listView1.Items)
        {
            lit.Add(itt);
        }
    }));
    foreach (ListViewItem i in lit)
    {
        Task t = Task.Run(() =>
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(300, 10000));
        });
        tasklist.Add(t);
        
        if(tasklist.Count >= maximalethreads)
        {
            Task.WaitAll(tasklist.ToArray());
            tasklist.Clear();
        }
    }
