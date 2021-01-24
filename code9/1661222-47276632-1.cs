    public class Enroll
    {
        [Key]
        public intId { get; set; }
        [Required]
        public string StudentId { get; set; }
        public IEnumerable<Courses> Courses { get; set; }
    }
