    class MyProgram
    {
        Service svc;
        UserControl ctrl;
        public MyProgram()
        {
            // create the control
            ctrl = new UserControl();
            // create the service
            svc = new Service();
            svc.SaveEvent += FileChanges;
            /////// you might construct something like:   _(do not use both)_
            svc.SaveEvent += (s, e) => ctrl.FileIsSaved(e.Filename);
        }
        private void FileChanges(object sender, ServiceFileChangedEventArgs e)
        {
            ctrl.FileIsSaved(e.Filename);
        }
    }
---
    class Service
    {
        // FileSystemWatcher
        private FileSystemWatcher _watcher;
        public Service() // constructor
        {
            // construct it.
            _watcher = new FileSystemWatcher();
            _watcher.Changed += Watcher_Changed;
        }
        // when the file system watcher raises an event, you could pass it thru or construct a new one, whatever you need to pass to the parent object
        private void Watcher_Changed(object source, FileSystemEventArgs e)
        {
            SaveEvent?.Invoke(this, new ServiceFileChangedEventArgs(e.FullPath)); // whatever
        }
        public event EventHandler<SaveEventEventArgs> SaveEvent;
    }
    class SaveEventEventArgs : EventArgs
    {
        // filename etc....
    }
