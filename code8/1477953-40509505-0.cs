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
            svc.Changed += FileChanges;
            /////// you might construct something like:   _(do not use both)_
            svc.Changed += (s, e) => ctrl.SaveEvent(e.Filename);
        }
        private void FileChanges(object sender, ServiceFileChangedEventArgs e)
        {
            ctrl.SaveEvent(e.Filename);
        }
    }
---
    class Service
    {
        private FileSystemWatcher _watcher;
        public Service() // constructor
        {
            _watcher = new FileSystemWatcher();
            _watcher.Changed += Watcher_Changed;
        }
        private void Watcher_Changed(object source, FileSystemEventArgs e)
        {
            Changed?.Invoke(this, new ServiceFileChangedEventArgs(e.FullPath)); // whatever
        }
        public event EventHandler<ServiceFileChangedEventArgs> Changed;
    }
    class ServiceFileChangedEventArgs : EventArgs
    {
        // filename etc....
    }
