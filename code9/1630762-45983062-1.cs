    public class MyContext : NotifyPropertyChanged
    {
        ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged("Students"); }
        }
        Student _selectedStudent = new Student();
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; OnPropertyChanged("SelectedStudent"); }
        }
    }
