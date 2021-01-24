    public class CourseListVm
    {
       public int? CategoryId { set;get;}
       public List<SelectListItem> Categories { set;get;}
       public IEnumerable<CourseVm> Courses { set;get;}
       public CourseListVm()
       {
           this.Courses = new List<CourseVm>();
       }
    }
    public class CourseVm
    {
       public int Id { set;get;}
       public string Name { set;get;}
    }
