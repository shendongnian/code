    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            courses = new ObservableCollection<Course>()
            {
                new Course() { CourseName = "blabla"},
                new Course() { CourseName = "bloblo"},
                new Course() { CourseName = "jojo"}
            };
        }
        ObservableCollection<Course> courses;
        public ObservableCollection<Course> Courses { get => courses; set => courses = value; } 
    }
    public class Course
    {
        public string CourseName { get; set; }
    }
