    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public static void Run()
    {
        try
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            //watcher.Path = System.IO.Directory.GetCurrentDirectory();
            watcher.Path = Path.Combine(HttpRuntime.AppDomainAppPath, "view");
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "info.txt";
    
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
    
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        string fileText = File.ReadAllText(e.FullPath);
        // do whatever you want to do with fileText
    }
