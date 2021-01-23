    public class TempDir
    {
        private string _path;
        public TempDir(string path)
            : this(path, false) { }
        public TempDir(string path, bool killExisting)
        {
            _path = path;
            if (!killExisting) return;
            if (Directory.Exists(_path))
                Directory.Delete(_path);
        }
        public string Path => _path;
        public string ActiveDirectory
            => _path.Substring(_path.LastIndexOf('/') + 1, 
               _path.Length - _path.LastIndexOf('/') - 1);
        ~TempDir()
        {
            if (System.IO.Directory.Exists(_path))
                Directory.Delete(_path, true);
            _path = null;
        }
        public static implicit operator string(TempDir dir)
        {
            return dir._path;
        }
    }
