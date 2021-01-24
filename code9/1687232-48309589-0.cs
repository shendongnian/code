    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Student _selectedStudent;
        private StudentFaculty _selectedFaculty;
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<StudentFaculty> Faculties { get; set; }
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent == value) return;
                _selectedStudent = value;
                OnChangedProperty("SelectedStudent");
            }
        }
        public StudentFaculty SelectedFaculty
        {
            get => _selectedFaculty;
            set
            {
                if (_selectedFaculty == value) return;
                _selectedFaculty = value;
                OnChangedProperty("SelectedFaculty");
            }
        }
        public ApplicationViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student("Vova", "Zyabkin", StudentFaculty.Programmer, 9.4),
                new Student("Vadym", "Lazariev", StudentFaculty.Programmer, 9),
                new Student("SvEta", "Belyaeva", StudentFaculty.Designer, 9.8),
                new Student("Vova", "Skachkov", StudentFaculty.SysAdministration, 8.7)
            };
            Faculties = new ObservableCollection<StudentFaculty>(Enum.GetValues(typeof(StudentFaculty)).OfType<StudentFaculty>());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChangedProperty(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
    public enum StudentFaculty { Programmer, SysAdministration, Designer };
    class Student : INotifyPropertyChanged
    {
        private string _name;
        private string _lastname;
        private StudentFaculty _faculty;
        private double _averageMark;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                if (_lastname == value) return;
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }
        public StudentFaculty Faculty
        {
            get => _faculty;
            set
            {
                if (_faculty == value) return;
                _faculty = value;
                OnPropertyChanged("Faculty");
            }
        }
        public double AverageMark
        {
            get => _averageMark;
            set
            {
                if (_averageMark == value) return;
                _averageMark = value;
                OnPropertyChanged("AverageMark");
            }
        }
        public Student() { }
        public Student(string name, string lastname, StudentFaculty faculty, double averageMark)
        {
            Name = name;
            Lastname = lastname;
            Faculty = faculty;
            AverageMark = averageMark;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
