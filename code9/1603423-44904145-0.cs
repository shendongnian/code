    public MainPage()
    {
        InitializeComponent();
        MainDrawer.DrawerLength = Window.Current.Bounds.Width;
        Loaded += (s, e) =>
        {
            // GetChildByName: https://github.com/JustinXinLiu/Continuity/blob/master/Continuity/Extensions/UtilExtensions.cs#L44
            var menuButton = MainDrawer.GetChildByName<Button>("PART_SideDrawerButton");
            menuButton.Click += (s1, e1) => DrawerGrid.Opacity = 1;
        };
        MainDrawer.RegisterPropertyChangedCallback(RadSideDrawer.DrawerStateProperty, (s, e) =>
        {
            var state = MainDrawer.DrawerState;
            if (state == DrawerState.Closed)
            {
                DrawerGrid.Opacity = 0;
            }
        });
    }
