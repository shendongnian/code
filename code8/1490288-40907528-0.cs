    public partial class App : Application
    {       
    	public App()
    		:base()
    	{
    		CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
    		CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");
    	}
    
    }
