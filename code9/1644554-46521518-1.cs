    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryID { get; set; }
    }
