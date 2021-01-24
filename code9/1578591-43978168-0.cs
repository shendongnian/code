    public UserControl()
    {
        InitializeComponent();
        NameScope.SetNameScope(second, NameScope.GetNameScope(this));
    }
