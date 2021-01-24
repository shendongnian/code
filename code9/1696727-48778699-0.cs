     [Table("Intranet_Comments")]
    public class Intranet_Comments
    {
        [Key]
        public int ic_id { get; set; }
        [ForeignKey("Intranet_Article")]
        public int ic_blid { get; set; }
        public string ic_comment { get; set; }
        public DateTime ic_crtdte { get; set; }
        public string ic_pcname { get; set; }
        public virtual Article Article { get; set; }       
       
    }
