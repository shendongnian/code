    BlockingCollection<WebClient> ClientQueue = new BlockingCollection<WebClient>();
    for (int i = 0; i < 2; i++)
    {
        var worker = new WebClient();
        worker.DownloadStringCompleted += (sender, e) => HandleJson(sender, e, ClientQueue);
        ClientQueue.Add(worker);
    }
