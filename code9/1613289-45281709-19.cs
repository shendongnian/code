    using Prism.Unity;
    using Xamarin.Forms;
    
    namespace XamPrismShared
    {
    	public partial class App : PrismApplication
    	{
    		public App (IPlatformInitializer platformInitializer):base(platformInitializer)
    		{						
    		}
    
    	    protected override void OnInitialized()
    	    {
    	        InitializeComponent();
    	        NavigationService.NavigateAsync("MainPage");
    	    }
    
    	    protected override void RegisterTypes()
    	    {
    	        Container.RegisterTypeForNavigation<NavigationPage>();
    	        Container.RegisterTypeForNavigation<MainPage>();	        
    	    }                
    	}
    }
