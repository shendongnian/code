    public class Application 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Note { get; set; }
        public Developer Owner { get; set;}
    }
