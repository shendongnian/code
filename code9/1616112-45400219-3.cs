    public class FileWatcher : DispatcherObject, INotifyPropertyChanged //Dispatcher object is necessary to call the right dispatcher from the background thread
    {
        //collect all events from the filewatcher
        public ObservableCollection<string> EventsFired
        {
            get
            {
                return _eventsFired;
            }
            set
            {
                _eventsFired = value;
                OnPropertyChanged();
            }
        }
        private FileSystemWatcher _fileWatcher;
        private ObservableCollection<string> _eventsFired;
        public FileWatcher(string Location)
        {
            //save all fired events
            _eventsFired = new ObservableCollection<string>();
            _fileWatcher = new FileSystemWatcher(PathLocation(Location));
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.Created += _fileWatcher_Created;
            _fileWatcher.EnableRaisingEvents = true;
        }
        private string PathLocation(string Location)
        {
            string value = String.Empty;
            try
            {
                value = Location;
                if (value != string.Empty)
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                //Implement logging on future version
            }
            return value;
        }
        void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            //necessary to refresh collection from background thread
            Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
            {
                EventsFired.Add(String.Format("Evento criado por " + Environment.UserName + " Em " + DateTime.Now + " File Created: Patch:{0}, Name:{1}", e.FullPath, e.Name));
            }));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
