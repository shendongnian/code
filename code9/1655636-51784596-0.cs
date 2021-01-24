    class _files
    {
        public string Id { get; set; }
        public string filename { get; set; }
        public string mimeType { get; set; }
        public long length { get; set; }
        public int chunks{ get; set; }
        public DateTime uploadDate { get; set; }
        public object metadata { get; set; } //You could replace object with a custom class
    }
