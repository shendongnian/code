    public Student SelectedStudent
    {
        get
        {
            return _selectedStudent;
        }
        set
        {
            _selectedStudent = value;
            OnPropertyChanged("SelectedStudent"); // your version of this notifier
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }
