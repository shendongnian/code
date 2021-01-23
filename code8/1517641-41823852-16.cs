    public static string ErrorMessgae
    {
        get { return errorMessage; }
        set
        {
            errorMessage = value;
            NotifyStaticPropertyChanged("ErrorMessgae"); // not "errorMessage"
        }
    }
