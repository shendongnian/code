    static void Main(string[] args)
    {
        var client = new WebClient();
        Object LockObject = new Object();
        DateTime LastProgressUpdateTime = DateTime.MinValue;
        long LastProgressUpdatePosition = -1;
        TimeSpan DesiredProgressUpdatePeriod = TimeSpan.FromMilliseconds(1500);
        client.DownloadProgressChanged += (o, e) =>
        {
            //Prevent multipe concurrent thread to update progress at once
            lock (LockObject)
            {
                // This prevents updating progress to value that is lower than
                // what we already printed. This could happen when threads
                // enters lock out of order.
                if (LastProgressUpdatePosition > e.BytesReceived)
                    return;
                // This is not neccessary, but prevents you to miss 100% progress event ()
                var isCompleted = e.TotalBytesToReceive != 0 && e.BytesReceived == e.TotalBytesToReceive;
                // Check if desired time elapsed since last update
                bool UpdatePeriodElapsed = DateTime.Now >= LastProgressUpdateTime + DesiredProgressUpdatePeriod;
                if(isCompleted || UpdatePeriodElapsed)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write(e.ProgressPercentage + "%");
                    LastProgressUpdatePosition = e.BytesReceived;
                    LastProgressUpdateTime = DateTime.Now;
                }
            }
        };
        client.DownloadFileAsync(new Uri("..."), "...");
        Console.ReadKey();
    }
