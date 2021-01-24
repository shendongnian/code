    public class EmployeeCustom : ObservableBase
    {
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                if (_employee != null)
                    _employee.PropertyChanged -= OnEmployeePropertyChanged;
                if(value != null)
                    value..PropertyChanged += OnEmployeePropertyChanged;
                this.Update(x => x.Employee, () => _employee = value, _employee, value);
            }
        }
        public Visibility SeniorTestVisible
        {
            get { return Employee.Level == EmployeeStatus.Senior && Employee.State == RecordState.Add ? Visibility.Visible : Visibility.Collapsed; }
        }
        public void OnEmployeePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Level" || e.PropertyName == "State")
            {
                this.NotifyPropertyChanged("SeniorTestVisible");
            }
        }
    }
