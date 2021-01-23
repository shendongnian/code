    public MainWindow()
    {
      InitializeComponent();
      AppWindow = this; // Here you set the static member to reference this MainWindow.
    }
    
    public static MainWindow AppWindow
    {
      get;
      private set;
    }
