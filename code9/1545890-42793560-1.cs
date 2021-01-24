    string ThreadID = Thread.CurrentThread.ManagedThreadId.ToString();
    await Task.WhenAll(urlList.Select(async url =>
    {
       string TaskThreadID = Thread.CurrentThread.ManagedThreadId.ToString();
       byte[] URLContents = await GetWebPageAsync(url);
       string TaskThreadID2 = Thread.CurrentThread.ManagedThreadId.ToString();
       lock (locker) { webResults.Add(URLContents); }
         }));
