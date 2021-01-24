    protected override void InitializeModule()
    {
        RegionManager.RegisterViewWithRegion("MenuRegion", typeof(MyOptionOneMenuItem));
        RegionManager.RegisterViewWithRegion("MenuRegion", typeof(MyOptionTwoMenuItem));
    }
