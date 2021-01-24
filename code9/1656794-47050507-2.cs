    private class MockWatchableFileSystem : IWatchableFileSystem
    {
        /// <inheritdoc />
        public MockWatchableFileSystem()
        {
            Watcher = new Mock<FileSystemWatcherBase>();
            AsMock = new MockFileSystem();
            AsMock.AddDirectory("/dev/bus/usb");
            Watcher.SetupAllProperties();
        }
        public MockFileSystem AsMock { get; }
        /// <inheritdoc />
        public DirectoryBase Directory => AsMock.Directory;
        /// <inheritdoc />
        public IDirectoryInfoFactory DirectoryInfo => AsMock.DirectoryInfo;
        /// <inheritdoc />
        public IDriveInfoFactory DriveInfo => AsMock.DriveInfo;
        /// <inheritdoc />
        public FileBase File => AsMock.File;
        /// <inheritdoc />
        public IFileInfoFactory FileInfo => AsMock.FileInfo;
        /// <inheritdoc />
        public PathBase Path => AsMock.Path;
        public Mock<FileSystemWatcherBase> Watcher { get; }
        /// <inheritdoc />
        public FileSystemWatcherBase CreateWatcher() => Watcher.Object;
    }
