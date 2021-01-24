    public class OfficeAssignment
    {
        [Key, ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
