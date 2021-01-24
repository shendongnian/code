    // Manual method - you control the relationship table
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual IList<TeachersStudents> TeachersStudents { get; set; }
    }
    
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual IList<TeachersStudents> TeachersStudents { get; set; }
    }
    
    public class TeachersStudents
    {
        [Key]
        public int Id { get; set; }
        [Index("IX_Teacher_Student", 1)]
        public int TeacherId { get; set; }
        [Index("IX_Teacher_Student", 2)]
        public int StudentId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
    
    // Automatic method - Entity Framework controls the relationship table
    public class TeacherEF
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual IList<StudentEF> StudentEFs { get; set; }
    }
    
    public class StudentEF
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual IList<TeacherEF> TeacherEFs { get; set; }
    }
