    public partial class App : Application
    {
    	public App()
    	{
    		InitializeComponent();
    
    		MasterDetailPage mdpage = new MasterDetailPage();
    		mdpage.Master = new ContentPage() { Title = "Master", BackgroundColor = Color.Red };
    		ToolbarItem tbi = new ToolbarItem() { Text = "POPUP" };
    		tbi.Clicked += async (object sender, System.EventArgs e) => {
    
    			StackLayout sl = new StackLayout() { HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Start, BackgroundColor = Color.Pink, WidthRequest  = 100, HeightRequest = 200 };
    			Rg.Plugins.Popup.Pages.PopupPage mypopup = new Rg.Plugins.Popup.Pages.PopupPage() {BackgroundColor = Color.Transparent };
    			mypopup.Content = sl;
    			await MainPage.Navigation.PushPopupAsync(mypopup);
    		};
    		ContentPage detail = new ContentPage() { Title = "Detail", BackgroundColor = Color.Green,  };
    		detail.ToolbarItems.Add(tbi);
    		mdpage.Detail = new NavigationPage(detail);
    		MainPage = mdpage;
    	}
    
    	protected override void OnStart()
    	{
    		// Handle when your app starts
    	}
    
    	protected override void OnSleep()
    	{
    		// Handle when your app sleeps
    	}
    
    	protected override void OnResume()
    	{
    		// Handle when your app resumes
    	}
    }
