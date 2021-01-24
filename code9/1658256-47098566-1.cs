    class NavigationViewModel : INotifyPropertyChanged
    {
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public DepartmentViewModel DepartmentViewModel { get; set; }
        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        
        public NavigationViewModel()
        {
            SelectedViewModel = new EmployeeViewModel(OpenEmp);
        }
        private void OpenEmp(object obj)
        {
            if (obj.ToString() == "Dept")
            {
                SelectedViewModel = new DepartmentViewModel();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    
