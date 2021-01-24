    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var initApplicationContext = new InitApplicationContext();
        SynchronizationContext context = SynchronizationContext.Current;
        Console.WriteLine();
        string path = Path.GetFullPath("../..");
        Console.WriteLine($"Watching {path}");
        var fileSystemWatcher = new FileSystemWatcher(path, "watcher");
        fileSystemWatcher.Changed += (sender, args) =>
        {
            context.Post(o =>
            {
                Console.WriteLine("Watched");
                initApplicationContext.Show();
            }, null);
        };
        fileSystemWatcher.EnableRaisingEvents = true;
        Application.Run(initApplicationContext);
    }
