    private Student _cmbSelected;
    public Student CmbSelected
    {
        get { return _cmbSelected; }
        set
        {
            _cmbSelected = value;
            if (_cmbSelected != null)
            {
                SelectedStudents = new List<Student>() { _cmbSelected };
            }
            else
            {
                SelectedStudents = new List<Student>();
            }
            OnPropertyChanged();
        }
    }
    private List<Student> _selectedStudents;
    public List<Student> SelectedStudents
    {
        get { return _selectedStudents; }
        set
        {
            _selectedStudents = value;
            OnPropertyChanged();
        }
    }
