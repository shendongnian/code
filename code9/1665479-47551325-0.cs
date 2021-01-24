    private static Task CreateTask(int i, string path, string sid, string lockFile)
    {
        return new Task(() =>
        {
            var start = DateTime.Now;
            Debug.WriteLine("Task {0} start:  {1:HH:mm:ss.fffffff}", i, start);
            Task.WaitAll(WaitForFileToUnlock(lockFile, () =>
            {
                var fileSystemAccessRule = new FileSystemAccessRule(new SecurityIdentifier(sid),
                    FileSystemRights.Modify | FileSystemRights.Synchronize,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);
                var directorySecurity = Directory.GetAccessControl(path);
                directorySecurity.ResetAccessRule(fileSystemAccessRule);
                Directory.SetAccessControl(path, directorySecurity);
            }));
            Debug.WriteLine("Task {0} finish: {1:HH:mm:ss.fffffff} ({2} ms)", i, DateTime.Now, (DateTime.Now - start).TotalMilliseconds);
        });
    }
    private static async Task WaitForFileToUnlock(string lockFile, Action runWhenUnlocked)
    {
        while (true)
        {
            try
            {
                using (new FileStream(lockFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    runWhenUnlocked();
                }
                return;
            }
            catch (IOException exception)
            {
                await Task.Delay(100);
            }
        }
    }
