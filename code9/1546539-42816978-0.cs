    myWebClient.DownloadFileCompleted += DownloadCompleted;
    public static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
    {
        Console.WriteLine("Success");
    }
