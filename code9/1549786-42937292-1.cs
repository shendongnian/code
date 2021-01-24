    public class FileItem
    {
        public FileItem (string path) => FullPath = path;
        public string FullPath { get; }
        public override ToString() => Path.GetFileName(FullPath);
    }
