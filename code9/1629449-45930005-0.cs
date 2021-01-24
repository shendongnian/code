    public static MainWindowViewModel SingletonInstance { get; set; }
    public MainWindowViewModel()
    {
        if (SingletonInstance == null)
        {
            SingletonInstance = this;
        }
    }
