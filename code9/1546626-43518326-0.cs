    public MainPage()
    {
        this.InitializeComponent();
        ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
        var bound = ApplicationView.GetForCurrentView().VisibleBounds;
        innerSearchBox.Width = (int)bound.Width - 48;        //48 is the size of the button
    }
    private void MainPage_VisibleBoundsChanged(ApplicationView sender, object args)
    {
        var bound = ApplicationView.GetForCurrentView().VisibleBounds;
        innerSearchBox.Width = (int)bound.Width - 48;
    }
