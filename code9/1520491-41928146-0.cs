    public RemoveGap()
    {
       this.InitializeComponent(); 
       if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
       {
           StatusBar.GetForCurrentView().HideAsync();  
       }
    }
