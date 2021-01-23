        // Put timer on your form, equivalent to:
        // Update_Timer = new System.Windows.Forms.Timer();
        // Update_Timer.Interval = 500;
        // Update_Timer.Tick += Timer_Tick;
        private void Download_Begin()
        {
            web_client = new System.Net.WebClient();
            web_client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Download_Progress);
            web_client.DownloadFileCompleted += new AsyncCompletedEventHandler(Download_Complete);
            Program.Downloading = true;
            Download_Success = false;
            stop_watch = System.Diagnostics.Stopwatch.StartNew();
            Update_Timer.Start();
            web_client.DownloadFileAsync(new Uri("uri"), "path");
        }
        private int _Progress;
        private void Download_Progress(object sender, DownloadProgressChangedEventArgs e)
        {
            _Progress = e.ProgressPercentage;
        }
        private void Download_Complete(object sender, AsyncCompletedEventArgs e)
        {
            Update_Timer.Stop();
            Program.Downloading = false;
            Download_Success = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Your code to update remaining time and speed
            // this.label_rate.Text = ...
            // this.time_remaining.Text = ...
            progressBar1.Value = _Progress;
        }
