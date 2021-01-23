    using Xamarin.Forms;
    
    namespace PersistWebViewSample
    {
    	public class StartPage : ContentPage
    	{
    		public StartPage()
    		{
    			var navigateToWebViewButton = new Button
    			{
    				Text = "Open Persistent Web View"
    			};
    			navigateToWebViewButton.Clicked += async (sender, e) => await Navigation.PushAsync(App.PersistentWebView);
    
    			Title = "Start";
    
    			Content = new StackLayout
    			{
    				Children ={
    					navigateToWebViewButton
    				}
    			};
    		}
    	}
    
    	public class App : Application
    	{
    		static readonly string xamarinUrl = "https://www.xamarin.com/";
    
    		public App()
    		{
    
    			MainPage = new NavigationPage(new StartPage());
    		}
    
    		public static ContentPage PersistentWebView { get; } = new ContentPage
    		{
    			Title = "Persistent Web View",
    			Content = new WebView
    			{
    				Source = xamarinUrl
    			}
    		};
    	}
    }
