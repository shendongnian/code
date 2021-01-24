    public class Course
    {
    	[InverseProperty(nameof(User.CoursesRunning))]
    	public virtual User User { get; set; }
    	[InverseProperty(nameof(User.CoursesTaking))]
    	public virtual ICollection<User> Users { get; set; }
    }
