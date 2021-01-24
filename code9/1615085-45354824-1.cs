    internal class FileWrapper : IFileWrapper
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
