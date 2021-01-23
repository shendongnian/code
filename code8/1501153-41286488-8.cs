    public class TempDir : IDisposable
    {
        private readonly string _path;
        public string ActiveDirectory => _path.Substring(_path.LastIndexOf('/') + 1, (_path.Length - _path.LastIndexOf('/') - 1));
    
        public string Path => _path;
        public TempDir(string path) : this(path, false) { }
        public TempDir(string path, bool KillExisting)
        {
            _path = path;
            if(KillExisting && Directory.Exists(_path))
            {
                Directory.Delete(_path);
            }
            //why not call Directory.CreateDirectory(_path) here?
        }
    
        public void Dispose( )
        {
            Cleanup();
        }
        ~TempDir()
        {
            Cleanup();
        }
        private void Cleanup()
        {
            if(Directory.Exists(_path))
            {
                Directory.Delete(_path, true);
            }
        }
    
        public static implicit operator String(TempDir dir) => dir._path;
    }
