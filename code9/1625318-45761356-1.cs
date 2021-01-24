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
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(_folderWatcher.ProcessFiles);
                _timer.Interval = 5000;
                _timer.Start();
            }
        }
