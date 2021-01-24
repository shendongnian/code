    public class User
    {
        [InverseProperty(nameof(Course.User))]
        public virtual ICollection<Course> CoursesRunning { get; set; }
        [InverseProperty(nameof(Course.Users))]
        public virtual ICollection<Course> CoursesTaking { get; set; }
    }
