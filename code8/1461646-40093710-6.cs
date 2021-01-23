    public class ContentTagAssignment
    {
        public ContentTagAssignment()
        {
            this.ContentExternalLink = new ContentExternalLink();
        }
        [Key]
        public string TagId { get; set; }
        [Key]
        public string ArticleId { get; set; }
        public string LinkId { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public virtual ContentExternalLink ContentExternalLink { get; set; }
    }
