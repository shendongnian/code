    public class FileEntry
    {
        public string file { get; set; }
        public string ext { get; set; }
        public string size { get; set; }
    }
    
    public class FileList
    {
        public int code { get; set; }
        public List<FileEntry> priv { get; set; }
        public List<FileEntry> pub { get; set; }
    }
