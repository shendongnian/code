    public class CourseVm
    {
      public int Id { set; get;}
      public string Name { set; get;}
    } 
    public class CoursesTeacher
    {
      public int Id { set;get;}
      public string FullName { set;get;}
      public List<CourseVm> Courses { set;get;}
    }
