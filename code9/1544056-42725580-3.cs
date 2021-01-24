    //Somewhere in your constructor / initializer:
    tracker = new DownloadProgressTracker(50, TimeSpan.FromMilliseconds(500));
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        tracker.SetProgress(e.BytesReceived, e.TotalBytesToReceive);
        pBarFileProgress.Value = tracker.GetProgress() * 100;
        label1.Text = e.BytesReceived + "/" + e.TotalBytesToReceive;
        label2.Text = tracker.GetBytesPerSecondString();
    }
