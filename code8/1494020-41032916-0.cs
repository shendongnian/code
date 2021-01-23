    public class PostData
    {
        public int ApplicationVersion { get; set; };
        public long Imei { get; set; };
        public string GoogleId { get; set; };
        public string FromDate { get; set; };
        public string ToDate { get; set; };
        public string ImagesVersion { get; set; };
        public ItemId[] SendIds { get; set; };
    }
    
    public class ItemId
    {
        public int Id { get; set; };
    }
