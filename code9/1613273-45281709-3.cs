    using Prism.Mvvm;
    
    namespace XamPrismShared.ViewModels
    {
    	public class MainPageViewModel : BindableBase
    	{
            public MainPageViewModel()
            {
                Title = "Hi from Prism.";
            }
    
    	    public string Title { get; set; }
    	}
    }
