    public static string ErrorMessage
    {
        get { return errorMessage; }
        set
        {
            errorMessage = value;
            NotifyStaticPropertyChanged("ErrorMessage");
        }
    }
