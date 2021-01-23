        Timer timer = new Timer();
        public Program()
        {
            timer.Interval = 5000;
            timer.Elapsed += DownloadUpdate;
            timer.Enabled = true;
        }
        private void DownloadUpdate(object sender, ElapsedEventArgs e)
        {
            Task.Factory.StartNew((Action)DownloadUpdate).ContinueWith(t =>
            {
                bool shouldTimerStartAgain = true;
                if (t.IsFaulted)
                {
                    // handle t.Exception
                    // Compute if this task need to stop?
                    // If so set shouldTimerStartAgain = false
                }
                if (shouldTimerStartAgain)
                {
                    timer.Start();
                }
            });
        }
        private void DownloadUpdate()
        {
            var package = string.Empty;
            if (_server != null)
            {
                timer.Stop();
                package = _server.Download();
                if (package.Length > 0)
                    _server.Install(package);
            }
        }
