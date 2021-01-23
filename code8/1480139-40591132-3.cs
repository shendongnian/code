    public class CourseViewModel : ViewModelBase
    {
        #region Fields
        private string _name;
        private ObservableCollection<StudentViewModel> _students;
        #endregion Fields
        #region Constructors
        public CourseViewModel()
        {
            _students = new ObservableCollection<StudentViewModel>();
            _students.CollectionChanged += _students_CollectionChanged;
        }
        #endregion Constructors
        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StudentViewModel> Students
        {
            get
            {
                return _students;
            }
        }
        public double TotalWeight
        {
            get
            {
                return Students.Sum(x => x.Weight);
            }
        }
        #endregion Properties
        #region Methods
        private void _students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // add/remove property changed handlers to students 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (StudentViewModel student in e.NewItems)
                {
                    student.PropertyChanged += Student_PropertyChanged;
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (StudentViewModel student in e.OldItems)
                {
                    student.PropertyChanged -= Student_PropertyChanged;
                }
            }
            //students were added or removed to the course -> inform "listeners" that TotalWeight has changed
            OnPropertyChanged(nameof(TotalWeight));
        }
        private void Student_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //the weight of a student has changed -> inform "listeners" that TotalWeight has changed
            if (e.PropertyName == nameof(StudentViewModel.Weight))
            {
                OnPropertyChanged(nameof(TotalWeight));
            }
        }
        #endregion Methods
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            var course1 = new CourseViewModel() { Name = "Course1" };
            course1.Students.Add(new StudentViewModel() { Weight = 100, Name = "Mark" });
            course1.Students.Add(new StudentViewModel() { Weight = 120, Name = "Olaf" });
            course1.Students.Add(new StudentViewModel() { Weight = 111, Name = "Hans" });
            var course2 = new CourseViewModel() { Name = "Course2" };
            course2.Students.Add(new StudentViewModel() { Weight = 100, Name = "Mark" });
            course2.Students.Add(new StudentViewModel() { Weight = 90, Name = "Renate" });
            course2.Students.Add(new StudentViewModel() { Weight = 78, Name = "Judy" });
            DataContext = new List<CourseViewModel>()
            {
                course1,
                course2
            };
        }
        #endregion Constructors
    }
    public class StudentViewModel : ViewModelBase
    {
        #region Fields
        private string _name;
        private double _weight;
        #endregion Fields
        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties
    }
