    public NewUnitUserControl()
    {
        InitializeComponent();
        CreateUnitViewModel cuvm = new CreateUnitViewModel();
        DataContext = nuvm;
        if (nuvm.CloseAction == null)
        {
            //var window = this.ParentForm; // window evaluates to null 
            //                                     // after this line.
            if(this.ParentForm != null)
            cuvm.CloseAction = new Action(this.ParentForm.Close);
        }
    }
