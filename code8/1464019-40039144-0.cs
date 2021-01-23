    public User UserRecord
    {
        get
        {
           if(userRecord == null)
             return userRecord = new User();
        }
        set
        {
            userRecord = value;
            onPropertyChanged("UserRecord");
        }
    }
