    public class Student {
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course {
        public virtual Student Student { get; set; }
    }
