    public class Student
    {
        public Student() 
        {
            this.Courses = new HashSet<Course>();
        }
    
        public int StudentId { get; set; }
        
        public string StudentName { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
    }
            
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
