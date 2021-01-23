    using System;
    using System.IO;
    using System.Collections.Generic;
    
    namespace Lerp2APIEditor.Utility
    {
        public class LerpedThread<T>
        {
            public T value = default(T);
            public bool isCalled = false;
            public string methodCalled = "";
            public Dictionary<string, Action> matchedMethods = new Dictionary<string, Action>();
    
            public FileSystemWatcher FSW
            {
                get
                {
                    return (FileSystemWatcher)(object)value;
                }
            }
            public LerpedThread(string name, FSWParams pars)
            {
                if(typeof(T) == typeof(FileSystemWatcher))
                {
                    FileSystemWatcher watcher = new FileSystemWatcher(pars.path, pars.filter);
    
                    watcher.NotifyFilter = pars.notifiers;
                    watcher.IncludeSubdirectories = pars.includeSubfolders;
    
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    watcher.Created += new FileSystemEventHandler(OnCreated);
                    watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                    watcher.Renamed += new RenamedEventHandler(OnRenamed);
    
                    ApplyChanges(watcher);
                }
            }
            private void OnChanged(object source, FileSystemEventArgs e)
            {
                methodCalled = "OnChanged";
                isCalled = true;
            }
            private void OnCreated(object source, FileSystemEventArgs e)
            {
                methodCalled = "OnCreated";
                isCalled = true;
            }
            private void OnDeleted(object source, FileSystemEventArgs e)
            {
                methodCalled = "OnDeleted";
                isCalled = true;
            }
            private void OnRenamed(object source, RenamedEventArgs e)
            {
                methodCalled = "OnRenamed";
                isCalled = true;
            }
            public void StartFSW()
            {
                FSW.EnableRaisingEvents = true;
            }
            public void CancelFSW()
            {
                FSW.EnableRaisingEvents = false;
            }
            public void ApplyChanges<T1>(T1 obj)
            {
                value = (T)(object)obj;
            }
        }
        public class FSWParams
        {
            public string path,
                          filter;
            public NotifyFilters notifiers;
            public bool includeSubfolders;
            public FSWParams(string p, string f, NotifyFilters nf, bool isf)
            {
                path = p;
                filter = f;
                notifiers = nf;
                includeSubfolders = isf;
            }
        }
    }
