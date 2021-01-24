    var clients = new ConcurrentBag<SftpClient>();
    Parallel.ForEach(files, (f, loopstate) => {
        if (!clients.TryTake(out var client))
        {
            client = new SftpClient(hostName, userName, password);
            client.Connect();
        }
        string localPath = Path.Combine(destPath, f.Name);
        Console.WriteLine(
            "Thread {0}, Connection {1}, File {2} => {3}",
            Thread.CurrentThread.ManagedThreadId, client.GetHashCode(), f.FullName, localPath);
        using (var stream = File.Create(localPath))
        {
            client.DownloadFile(f.FullName, stream);
        }
        clients.Add(client);
    });
    Console.WriteLine("Closing {0} connections", clients.Count);
    foreach (var client in clients)
    {
        client.Dispose();
    }
