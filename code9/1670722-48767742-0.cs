    public class Item 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
