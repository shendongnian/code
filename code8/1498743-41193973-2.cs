    public class StudentVm
    {
        public string FirstName { get; set; }
        ....
        IEnumerable<CourseVM> Courses { get; set; }
    }
    public class CourseVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
