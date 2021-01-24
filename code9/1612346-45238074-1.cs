    private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
    public ObservableCollection<Employee> Employees
    {
        get { return _employees; }
        protected set
        {
            if (_employees == value)
                return;
            _employees = value;
            OnPropertyChanged("Employees");
        }
    }
