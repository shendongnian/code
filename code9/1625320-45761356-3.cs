        public class TimedFolderWatcher
        {
            private readonly FolderWatcher _folderWatcher;
            private readonly Timer _timer;
    
            public TimedFolderWatcher(FolderWatcher folderWatcher)
            {
                _folderWatcher = folderWatcher;
                InitTimer();
            }
    
            private void InitTimer()
            {
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(this.ProcessFiles);
                _timer.Interval = 5000;
                _timer.Start();
            }
    
            private void ProcessFiles(object sender, ElapsedEventArgs e)
            {
                _folderWatcher.TryProcessFiles(sender, e);
            }
        }
