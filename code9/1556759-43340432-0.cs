    public interface IFileServerProvider
    {
        /// <summary>
        /// Contains a list of FileServer options, a combination of virtual + physical paths we can access at any time
        /// </summary>
        IList<FileServerOptions> FileServerOptionsCollection { get; }
        /// <summary>
        /// Gets the IFileProvider to access a physical location by using its virtual path
        /// </summary>
        IFileProvider GetProvider(string virtualPath);
    }
    /// <summary>
    /// Implements IFileServerProvider in a very simple way, for demonstration only
    /// </summary>
    public class FileServerProvider : IFileServerProvider
    {
        public FileServerProvider(IList<FileServerOptions> fileServerOptions)
        {
            FileServerOptionsCollection = fileServerOptions;
        }
        public IList<FileServerOptions> FileServerOptionsCollection { get; }
        public IFileProvider GetProvider(string virtualPath)
        {
            var options = FileServerOptionsCollection.FirstOrDefault(e => e.RequestPath == virtualPath);
            if (options != null)
                return options.FileProvider;
            
            throw new FileNotFoundException($"virtual path {virtualPath} is not registered in the fileserver provider");
        }
    }
