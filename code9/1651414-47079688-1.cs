    public DelegateCommand<object> CloseTabCommand { get; set; }
    
    public MainWindowViewModel(IRegionManager regionManager)
    {
    	this.regionManager = regionManager;
    
    	CloseTabCommand = new DelegateCommand<object>(OnCloseTab);
    
    }
    private void OnCloseTab(object tabItem)
    {
    	var view = ((System.Windows.Controls.TabItem)tabItem).DataContext;
    	this.regionManager.Regions["TabRegion"].Remove(view);
    }
