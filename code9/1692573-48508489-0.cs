    public interface IFileSystem
    {
        string ReadAllText(string path);
        //... other file system operations
    }
    public class WindowsFileSystem : IFileSystem
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
