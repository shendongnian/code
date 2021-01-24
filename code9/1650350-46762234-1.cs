    public CoolViewModel()
    {
        Tabs = new ObservableCollection<ITabViewModel>
        {
             new VeryNiceViewModel(),
             new VeryNiceViewModel()
        };
        Tabs.ForEach(x =>{
            x.OnChangeSelectedTab += x_OnChangeSelectedTab
        });
    
    }
    
    private void x_OnChangeSelectedTab(string tabName)
    {
         // select from List of tabItems tabItem with name == tabName and then set propetry in this tabItem to true.
         SomePropertyInParentViewModel = true;
    }
