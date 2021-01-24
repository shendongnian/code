    [ContentProperty("Elements")]
    public partial class CustomStackLayout : ContentView
    {
    	public CustomStackLayout()
    	{
    		InitializeComponent();
    	}
    
    	public IEnumerable<View> Elements { get; set; }
    }
