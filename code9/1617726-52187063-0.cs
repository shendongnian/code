    using Xamarin.Forms.PlatformConfiguration;
    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
    namespace Social.Mobile.Views
    {
	    public partial class MainPage : TabbedPage
	    {
		    public MainPage()
		    {
			    InitializeComponent();			
			    On<Android>().SetToolbarPlacement(value: ToolbarPlacement.Bottom);
		    }
	    }
    }
