    public class DownloadResult
    {
        public bool Success { get; set; }
        public byte[] FileContent { get; set; }
        public string DownloadName { get; set; }
        public string SizeInBytes { get; set; }
        //... any other useful properties
    }
