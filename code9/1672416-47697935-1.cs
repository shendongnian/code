    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
    public class ViewModel : Notifier
    {
        private JobType _selectedJobType;
        private string _newJobType;
        public JobTypeList JobTypes { get; private set; } 
        public JobType SelectedJobType { get => _selectedJobType; set { _selectedJobType = value; Notify(); } }
        public string NewJobType { get => _newJobType; set { _newJobType = value; Notify(); AddNewJobType(value); } }
        public ViewModel()
        {
            JobTypes = new JobTypeList();
            JobTypes.Add(new JobType { Name = "Butcher" });
            JobTypes.Add(new JobType { Name = "Baker" });
            JobTypes.Add(new JobType { Name = "LED maker" });
        }
        private void AddNewJobType(string name)
        {
            if(JobTypes.Any(x => x.Name == name)) return;
            JobTypes.Add(new JobType { Name = name });
            JobTypes.SortJobTypes();
        }
    }
    public class JobType : Notifier
    {
        private string _name;
        public string Name { get => _name; set { _name = value; Notify(); } }
    }
