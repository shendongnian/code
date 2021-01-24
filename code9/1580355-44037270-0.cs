    public static readonly MyWindow Singleton;
    public MyWindow()
    {
        InitializeComponent();
        
        if (Singleton == null)
            Singleton = this;
    }
