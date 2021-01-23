    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<StudentCourses> Students { get; set; }
    }
    
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<StudentCourses> Courses { get; set; }
    }
