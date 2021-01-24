    public string Profession
    {
        get
        {
    
            return _profession;
        }
        set
        {
            if (_profession != value && value != null)
            {
                _profession = value;
                OnPropertyChange();
            }
        }
    }
