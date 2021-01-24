    videoDownloader.DownloadProgressChanged += (sender, args) => // note the arrow here
    {
        if ((args.ProgressPercentage % 1) == 0)
        {
            Console.WriteLine(args.ProgressPercentage);
        }
    }; // note the semicolon here
