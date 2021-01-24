    public class OfficeAssignment
    {
        public int OfficeAssignmentId { get; set; }
        //Notice that Id does not have an uppercase D
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
