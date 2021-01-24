    {
        [Key]
        public int ic_id { get; set; }
        [ForeignKey("Article")]
        public int ic_blid { get; set; }
        public string ic_comment { get; set; }
        public DateTime ic_crtdte { get; set; }
        public string ic_pcname { get; set; }
        public virtual Article Article { get; set; }       
       
    }
