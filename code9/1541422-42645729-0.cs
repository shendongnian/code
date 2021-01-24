    public partial class MainPage : ContentPage
    {
    	public MainPage()
    	{
    		InitializeComponent();
    
    		this.FrameNav.Content = (new Page_Home()).Content;
    	}
    }
