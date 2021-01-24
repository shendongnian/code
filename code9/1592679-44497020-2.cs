    public UserSelectRibbon()
    {
        InitializeComponent();
        grid1.DataContext = this; // set DataContext on inner control instead of the usercontrol itself
    }
