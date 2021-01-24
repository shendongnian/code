    public class ViewModelFrom : BaseViewModel
    {
    	async Task ExecuteCommand()
         {
    		string routeName="value to trasfer";
            Navigation.PushAsync(new View(routeName));
         }
    }
    	
    	
    public partial class View : ContentPage
    {
    	public View(string routeName)
    	{
    		InitializeComponent();
            BindingContext = new ViewModelTo(routeName);
         }
    }
    public class ViewModelTo : BaseViewModel
    {
    	public string RouteName { get; set; }
    
    	public ViewModelTo(string routeName)
    	{
    	     RouteName=routeName;
    	}
    }
