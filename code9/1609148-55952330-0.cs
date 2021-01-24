    public class NewsModel : IActive
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NewsName { get; set; }
        public string NewsText { get; set; }
        public bool Active { get; set; }}
    {"id":0,"newsName":"123","newsText":"123","active":""}
