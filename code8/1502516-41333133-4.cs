            private double progress = 0;
        /// <summary>
        /// Progress of the download of the App. From 0.0 (%) to 100.0 (%)
        /// </summary>
        public double Progress
        {
            get { return progress; }
            set
            {
                // Max / Min
                double val = value;
                if (val > 100.0) val = 100;
                else if (val < 0.0) val = 0.0;
                // Assign value
                if (progress != val)
                {
                    progress = val;
                    OnProgressReport("Progress");
                    OnPropertyChanged("Progress");
                }
            }
        }
        public long downloadedSize = 0;
        /// <summary>
        /// Quantity of bytes downloaded of the app.
        /// Note: there can be more bytes downloaded than advertized because
        /// the quantity of advertize filesize is not encrypted while the
        /// received bytes are encrypted.
        /// TODO: advertize the size of the encrypted file.
        /// </summary>
        public long DownloadedSize
        {
            get
            {
                return downloadedSize;
            }
            set
            {
                if (downloadedSize != value)
                {
                    downloadedSize = value;
                    OnDownloadedSizeReport("DownloadedSize");
                }
            }
        }
    /// <summary>
        /// Fired when the progress of the download of the app file
        /// has updated (more bytes received).
        /// </summary>
        public event PropertyChangedEventHandler ProgressReport;
        protected void OnProgressReport(string name)
        {
            PropertyChangedEventHandler handler = ProgressReport;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
        /// <summary>
        /// Fired when the progress of the download of the app file
        /// has updated (more bytes received).
        /// </summary>
        public event PropertyChangedEventHandler DownloadedSizeReport;
        protected void OnDownloadedSizeReport(string name)
        {
            PropertyChangedEventHandler handler = DownloadedSizeReport;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
