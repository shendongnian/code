    public ObservableCollection<EmployeeViewModel> Employees {get;set;}
    public EmployeeViewModel CurrentEmployee
    { 
        get { return _currentEmployee;}
        set
        { 
            _currentEmployee = value;
            OnPropertyChanged("CurrentEmployee");
        }
    }
