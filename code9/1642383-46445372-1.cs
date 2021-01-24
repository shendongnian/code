    foreach (var item in source)
    {
       var worker = ClientQueue.Take();
       worker.DownloadStringAsync(uri, item);
    }
    public static void HandleJson(object sender, DownloadStringCompletedEventArgs e, BlockingCollection<WebClient> ClientQueue)
    {
        string item = (string)res.UserState;
        ...
    }
