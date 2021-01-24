    public class Student
    {
        // Your Student properties here
        [Index(IsUnique = true)]
        [ForeignKey("School")]
        public long SchoolId { get; set; }
        
        public virtual School School  { get; set; }
    }
