    public DevMonitor(
        [NotNull] IWatchableFileSystem fileSystem,
        [NotNull] IDeviceFileParser deviceFileParser,
        [NotNull] ILogger logger,
        [NotNull] string devDirectoryPath = DefaultDevDirectoryPath)
    {
        // ...
        _watcher = fileSystem.CreateWatcher();
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents = true;
        _watcher.Path = devDirectoryPath;
    }
