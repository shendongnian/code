    public Student SelectedStudent
    {
        get
        {
            return _selectedStudent;
        }
        set
        {
            _selectedStudent = value;
            RaisePropertyChanged("SelectedStudent"); // your version of this notifier
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }
