    public class DownloadRequest {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsProcessed { get; set; }
        public string Output { get; set; }
    
        public ICollection<DownloadCategory> DownloadCategories { get; set; } 
            = new HashSet<DownloadCategory>();
    }
