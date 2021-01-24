    public partial class App : Application
    {
    	public App()
    	{
    		InitializeComponent();
    
    		var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
    		var nav = new FreshNavigationContainer(page);
    		MainPage = nav;
    
    	}
    	
    	...
    }
