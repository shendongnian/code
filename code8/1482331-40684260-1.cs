    private int? _selectedNumber
    public int? SelectedNumber
    {
        get { return _selectedNumber; }
        set
        {
            _selectedNumber = value;
            NotifyPropertyChanged("SelectedNumber");
            if (_selectedNumber.HasValue) BindAtsData(_selectedNumber.Value);
            else { /* some kind of de-select needed? */ }
        }
    }
