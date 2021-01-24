    public MainPage()
    {
        InitializeComponent();
        MyPivot.Loaded += (s, e) => MyPivot.Focus(FocusState.Programmatic);
    }
