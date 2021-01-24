    internal class FileExist : IFileWrapper
    {
        public bool Exists(string path) => File.Exists(path);
    }
    public interface IFileWrapper
    {
        bool Exists(string path);
    }
