    public MyUserControl()
    {
        InitializeComponent();
        ((CreateDisplayTypeViewModel)DataContext).SetNewDisplayType();
    }
