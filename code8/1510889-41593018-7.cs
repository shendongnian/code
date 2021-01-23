    public bool Checked
    {
        get { return _checked; }
        set
        {
            _checked = value;
            OnPropertyChanged();
            CheckBoxStateChanged.Invoke(this, new CheckBoxStateChangedEventArgs() { CheckBoxChecked = value })            
        }
    }
