    while (true) {
        if (!client.Inbox.IsOpen)
            client.Inbox.Open(FolderAccess.ReadOnly);
        var task = client.IdleAsync (done.Token);
        Thread.Sleep(10000);
        done.Cancel();
        task.Wait();
    }
