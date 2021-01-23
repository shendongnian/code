    public class Program
    {
        static void Main(string[] args)
        {
            // Let's create our file system instance
            IFileSystem fileSystem = new WindowsFileSystem();
            // Create our directories
            fileSystem.CreateDirectories("/home/XXX/Documents/Users/Pepe/datos/", "/home/XXX/Documents/Users/Juan");
        }
    }
    /// <summary>
    /// Implementation for a Windows File System
    /// </summary>
    public class WindowsFileSystem : IFileSystem
    {
        public void CreateDirectories(params string[] directories)
        {
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
    /// <summary>
    /// Host File System Interface for all File system classes to abide by
    /// Allows for easy mocking during unit testing
    /// </summary>
    public interface IFileSystem
    {
        void CreateDirectories(params string[] directories);
    }
