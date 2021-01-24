    /// <inheritdoc />
    public sealed class WatchableFileSystem : IWatchableFileSystem
    {
        private readonly IFileSystem _fileSystem;
        /// <summary>
        /// Initializes a new instance of the <see cref="WatchableFileSystem" /> class.
        /// </summary>
        public WatchableFileSystem() => _fileSystem = new FileSystem();
        /// <inheritdoc />
        public DirectoryBase Directory => _fileSystem.Directory;
        /// <inheritdoc />
        public IDirectoryInfoFactory DirectoryInfo => _fileSystem.DirectoryInfo;
        /// <inheritdoc />
        public IDriveInfoFactory DriveInfo => _fileSystem.DriveInfo;
        /// <inheritdoc />
        public FileBase File => _fileSystem.File;
        /// <inheritdoc />
        public IFileInfoFactory FileInfo => _fileSystem.FileInfo;
        /// <inheritdoc />
        public PathBase Path => _fileSystem.Path;
        /// <inheritdoc />
        public FileSystemWatcherBase CreateWatcher() => new FileSystemWatcher();
    }
