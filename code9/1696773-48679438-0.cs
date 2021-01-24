    public interface IFileExistanceCheck
    {
        bool FileExist(string filePath);
    }
    public class FileExistanceChecker : IFileExistanceCheck
    {
        private readonly IFileSystem fileSystem;
        public FileExistanceChecker(IFileSystem fileSystem)
        {
            if (fileSystem == null)
                throw new ArgumentNullException(nameof(fileSystem));
            this.fileSystem = fileSystem;
        }
        // Pass runtime data through the method parameters!
        public bool FileExist(string filePath)
        {
            // Prevent an empty file path from being used
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            return this.fileSystem.File.Exists(filePath);
        }
    }
