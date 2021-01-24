    class MainPageViewModel
    {
        public string Name { get; set; }
        public List<Course> VMCourse;
        //This is now bound to the view's listview
        public List<Course> Courses {
            get
            {
                return VMCourse;
            }
        }
        public MainPageViewModel()
        {
            VMCourse = new List<Course>();
        }
        public void AddCourse()
        {
            Course NewCourse = new Course();
            NewCourse.Name = "New Course Added";
            VMCourse.Add(NewCourse);
        }
