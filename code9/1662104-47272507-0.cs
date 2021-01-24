    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        public string Title { get; set; }
        public string Body { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public Person Author { get; set; }
    }
