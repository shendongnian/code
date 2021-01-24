    private void SaverCallback()
    {
        AddThread("Main Thread");
        const string path = "milestone";
        while (!stop)
        {
            try
            {
                lock (JobQueue.Queue.MainQueue)
                lock (JobQueue.Queue.LockedQueue)
                {
                    using (var writingStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    {
                        var milestone = new ConcurrentDictionary<string, object>();
                        milestone.TryAdd("Jobs", JobQueue.Queue.MainQueue);
                        milestone.TryAdd("Locked Jobs", JobQueue.Queue.LockedQueue);
                        var formater = new BinaryFormatter();
                        formater.Serialize(writingStream, milestone);
                        writingStream.Flush();
                        Logger.Debug("Status saved");
                    }
                }
                // this line cloud be in finally case too,
                // if you don't need to save a queue in case of some errors
                this.WaitTime(60000);
            }
            catch(Exception e)
            {
                // note that logger accepts whole exception information
                // instead of only it's message
                Logger.Error($"Milestone exception: {e}");
                continue;
            }
        }
        RemoveThread();
    }
