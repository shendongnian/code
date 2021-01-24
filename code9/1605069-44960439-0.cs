    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        
        public List<StudentCourse> Courses { get; set; } // So you can access Courses for a student
    }
    
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> Students { get; set; }
    }
    
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }
    
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; } // Include this so you can access it later
        public int CourseId { get; set; }        
        [ForeignKey("CourseId")]
        public Course Course { get; set; } 
    }
