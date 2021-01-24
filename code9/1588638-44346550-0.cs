    using (var client = new WebClient())
    {
        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        client.DownloadProgressChanged += (o, e) =>
        {
            Console.SetCursorPosition(left, top);
            Console.Write(e.ProgressPercentage + "% ");
        };
        client.DownloadFileAsync(...);
        Console.ReadKey();
    }
