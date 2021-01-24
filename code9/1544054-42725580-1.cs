    //Somewhere in your constructor / initializer:
    tracker = new DownloadProgressTracker(50, TimeSpan.FromMilliseconds(500));
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        if(tracker == null)
            tracker = new DownloadProgressTracker(e.TotalBytesToReceive, 50, TimeSpan.FromMilliseconds(500));
        tracker.SetProgress(e.BytesReceived);
        pBarFileProgress.Value = tracker.GetProgress() * 100;
        label1.Text = e.BytesReceived + "/" + e.TotalBytesToReceive;
        label2.Text = tracker.GetBytesPerSecondString();
    }
