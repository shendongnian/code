    private usernameAvailable
    
    public bool UsernameAvailable 
    { 
        get
        {
            return usernameAvailable;
        }
        set
        {
            if (usernameAvailable != value)
            {
                usernameAvailable = value;
                OnPropertyChanged(nameof(UsernameAvailable));
            }
        }
    }
