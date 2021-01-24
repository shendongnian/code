    public class DirectoryFiles
    {
        public DirectoryFiles(string currentDir)
        {
            CurrentDir = currentDir;
            Files = Directory.GetFiles(currentDir, "*", SearchOption.TopDirectoryOnly)
                .OrderBy(o=> o);
            Directories = Directory.GetDirectories(currentDir)
                .Select(c => new DirectoryFiles(c))
                .OrderBy(o=> o.CurrentDir);
        }
    
        public string CurrentDir { get; set; }
        //// list of files in this directory
        public IEnumerable<string> Files { get; set; }
        //// list of directories in this directory
        public IEnumerable<DirectoryFiles> Directories { get; set; }
    }
