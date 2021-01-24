        public class Article
        {
        [Key]
        public int bl_id { get; set; }
        [Column("bl_title")]
        public string Title { get; set; }
        [Column("bl_img")]
        public string Image { get; set; }
        [Column("bl_summ")]
        public string Summary { get; set; }
        [AllowHtml]
        [Column("bl_content")]
        public string Content { get; set; }
        [Column("bl_author")]
        public string Author { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Column("bl_dtecrt")]
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
