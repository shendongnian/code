    public class FileManip {
        public FileManip(string path) {
            AppPath = path;   // <<===== ERROR
        }
        private string AppPath {
            get { return @"c:\temp\"; }
        }
    }
