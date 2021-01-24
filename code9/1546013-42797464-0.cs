    private DateTime _DOB;
    public DateTime DOB
    {
        get
        {
            return _DOB;
        }
        set
        {
            if (_DOB != value)
            {
                _DOB = value;
                RaisePropertyChanged();
                _age = DateTime.Now.Year - _DOB.Year;
                RaisePropertyChanged("Age");
            }
        }
    }
