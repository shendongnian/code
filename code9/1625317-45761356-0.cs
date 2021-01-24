        public class FolderWatcher
        {
            private readonly string _inPath;
            private readonly string _outPath;
    
            public FolderWatcher(string inPath, string outPath)
            {
                _inPath = inPath;
                _outPath = outPath;
            }
    
            public void ProcessFiles(object sender, ElapsedEventArgs e)
            {
                string[] originalFiles = GetFilesInDirectory();
                foreach (var originalFile in originalFiles)
                {
                    CheckFile(originalFile);
                }
            }
    
            // Internal/Virtual so that this can mocked in unit testing.
            internal virtual string[] GetFilesInDirectory()
            {
                return Directory.GetFiles(_inPath + @"\", "*.txt");
            }
    
            // Internal/Virtual so that this can mocked in unit testing.
            internal virtual void CheckFile(string fileName)
            {
                string infile = $"{_inPath}{fileName}";
                string outfile = $"{_outPath}{fileName}";
                File.Move(infile, outfile);
            }
    
        }
