    public class CoursesViewModel
    {
    	public List<string> CourseNames { get; set; }       
    	public List<string> AssignmentNames { get; set; }
    
    	public CoursesViewModel()
    	{
    		CourseNames = new List<string>();
    		AssignmentNames = new List<string>();
    	}
    }
