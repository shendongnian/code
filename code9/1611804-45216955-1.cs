    public class Student {
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course {
        public virtual ICollection<Student> Students { get; set; }
    }
