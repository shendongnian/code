    public AuditTestsMain()
    {
        InitializeComponent();
        //  Now its parent view can't bind this guy's properties to properties of the 
        //  parent's view's viewmodel, because we've broken DataContext inheritance. 
        DataContext = new ViewModels.AuditTests();
    }
