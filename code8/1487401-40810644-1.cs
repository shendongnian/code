    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            var q = new[] { new Project() { Name = "A" }, new Project() { Name = "B" }, new Project() { Name = "C" } };
            ProjectList = new ObservableCollection<Project>(q);
        }
        private ObservableCollection<Project> _projectList;
        public ObservableCollection<Project> ProjectList
        {
            get
            {
                return _projectList;
            }
            set
            {
                _projectList = value;
                OnPropertyChanged("ProjectList");
            }
        }
        Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }
        public ICommand DeleteCommand => new SimpleCommand(DeleteProject);
        private void DeleteProject()
        {
            if (SelectedProject != null)
            {
                ProjectList.Remove(SelectedProject);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Project
    {
        public string Name { get; set; }
    }
    public class SimpleCommand : ICommand
    {
        Action _execute;
        public SimpleCommand(Action execute)
        {
            this._execute = execute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            _execute();
        }
    }
