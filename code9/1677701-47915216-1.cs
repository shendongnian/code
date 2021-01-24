    public class Book
    {
        [Key]
        public int Id { get; set; }
    
        [Display(Name = "Select author")]
        public int AuthorId { get; set; }
    
        [Required]
        public string Title { get; set; }
    
        [Display(Name = "Publication date")]
        public DateTime? PublicationDate { get; set; }
    
        public float? Edition { get; set; }
        
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
?
