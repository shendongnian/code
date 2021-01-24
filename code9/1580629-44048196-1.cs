    public class MainWindowViewModel : INotifyPropertyChanged
    {
       public MainWindowViewModel()
        {            
            Students = new ObservableCollection<Student>();
            Students.Add(new Student { StudentGrade = 1, StudentName = "Jack" });
            Students.Add(new Student { StudentGrade = 2, StudentName = "Jill" });
            Students.Add(new Student { StudentGrade = 3, StudentName = "Humpty" });
        }
        private string _SearchText;
        //to be used to filer datagrid
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                //filter logic, I am filtering on base of student name, you can have your own implementation.
                Students = new ObservableCollection<Student>(Students.Where(x => x.StudentName.ToUpper().Contains(value.ToUpper())).ToList());
                NotifyPropertyChanged("SearchText");
            }
        }        
        private ObservableCollection<Student> _students;
        // to hold list of students
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                NotifyPropertyChanged("Students");
            }
        }        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
