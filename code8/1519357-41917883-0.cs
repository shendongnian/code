    public ObservableCollection<Course> Courses
        {
            get { return (ObservableCollection<Course>)GetValue(CoursesProperty); }
            set { SetValue(CoursesProperty, value); }
        }
    public static readonly DependencyProperty CoursesProperty =
            DependencyProperty.Register(nameof(Courses), typeof(ObservableCollection<Course>), typeof(MainPage));
