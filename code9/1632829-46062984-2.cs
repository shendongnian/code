    public class MyViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string StudentNumber { get; set; }
        // etc...
    }
