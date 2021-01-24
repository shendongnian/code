    public double Age
    {
        get { return _age; }
        set
        {
            if (_age != value)
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
                if (_age == 21) IsValid = false;
            }
            else
            {
                Debug.WriteLine("NO CHANGE");
            }
        }
    }
