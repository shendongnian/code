    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Required")]
        public string ArticleTitle { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArticleDate { get; set; }
        public Article()
        {
            ArticleDate = DateTime.Now;
        }
        [DataType(DataType.MultilineText)]
        public string ArticleDescriotion { get; set; }
        public string ArticleImage { get; set; }
    }
