    private void button1_Click(object sender, EventArgs e)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += Worker_DoWork;
        worker.RunWorkerAsync();
    }
    
    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        Download_Begin();
    }
    
    /// Downloads the file.
    private void Download_Begin()
    {
        web_client = new System.Net.WebClient();
        web_client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Download_Progress);
        web_client.DownloadFileCompleted += new AsyncCompletedEventHandler(Download_Complete);
        stop_watch = new System.Diagnostics.Stopwatch();
        stop_watch.Start();
        try
        {
            if (Program.Current_Download == "Install_Client.exe")
            {
                web_client.DownloadFileAsync(new Uri("http://www.website.com/Client/Install_Client.exe"), @"C:\Downloads\Install_Client.exe");
            }
            else
            {
                web_client.DownloadFileAsync(new Uri((string.Format("http://www.website.com/{0}", Program.Current_Download))), (string.Format(@"C:\Downloads\{0}", Program.Current_Download)));
            }
        }
        catch (Exception)
        {
            stop_watch.Stop();
        }
    
        Program.Downloading = true;
        Download_Success = false;
    }
    /// -------------------
    
    /// Tracks download progress.
    private void Download_Progress(object sender, DownloadProgressChangedEventArgs e)
    {
        this.BeginInvoke(new Action(() => 
        {
            double bs = e.BytesReceived / stop_watch.Elapsed.TotalSeconds;
    
            this.label_rate.Text = string.Format("{0} kb/s", (bs / 1024d).ToString("0.00"));
    
            long bytes_remaining = e.TotalBytesToReceive - e.BytesReceived;
            double time_remaining_in_seconds = bytes_remaining / bs;
            var remaining_time = TimeSpan.FromSeconds(time_remaining_in_seconds);
    
            string hours = remaining_time.Hours.ToString("00");
    
            if (remaining_time.Hours > 99)
            {
                hours = remaining_time.Hours.ToString("000");
            }
    
            this.time_remaining.Text = string.Format("{0}::{1}::{2} Remaining", hours, remaining_time.Minutes.ToString("00"), remaining_time.Seconds.ToString("00"));
    
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;
            if (e.ProgressPercentage == 100)
            {
                Download_Success = true;
            }
        }));
    }
