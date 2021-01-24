    /// <summary>
    /// Represents a(n) <see cref="IFileSystem" /> that can be watched for changes.
    /// </summary>
    public interface IWatchableFileSystem : IFileSystem
    {
        /// <summary>
        /// Creates a <c>FileSystemWatcher</c> that can be used to monitor changes to this file system.
        /// </summary>
        /// <returns>A <c>FileSystemWatcher</c>.</returns>
        FileSystemWatcherBase CreateWatcher();
    }
