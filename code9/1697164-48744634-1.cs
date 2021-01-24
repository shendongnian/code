    public MyUserControlViewModel MyUserControlSourceVM
    {
        get
        {
            return ServiceLocator.Current.GetInstance<MyUserControlViewModel>(Guid.NewGuid().ToString());
        }
    
    
    public MyUserControlViewModel MyUserControlTargetVM
    {
        get
        {
            return ServiceLocator.Current.GetInstance<MyUserControlViewModel>(Guid.NewGuid().ToString());
        }
    }
