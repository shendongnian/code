	public class App : Application
	{
		public App()
		{
			MainPage = new MasterDetail();
		}
	}
	public class MasterDetail : MasterDetailPage
	{
		static WebViewPage persistentWebPage = new WebViewPage();
		public MasterDetail()
		{
			var masterPage = new MasterPage();
			persistentWebPage = new WebViewPage();
			Master = masterPage;
			Detail = persistentWebPage;
			masterPage.listview.ItemSelected += (sender, e) =>
			{
				var item = e.SelectedItem as string;
				if (string.IsNullOrEmpty(item))
					return;
				switch (item)
				{
					case "1":
						Detail = persistentWebPage;
						break;
					default:
						Detail = new ContentPage { BackgroundColor = Color.Red };
						break;
				}
				masterPage.listview.SelectedItem = null;
				IsPresented = false;
			};
		}
	}
	public class MasterPage : ContentPage
	{
		public ListView listview = new ListView { ItemsSource = new string[] { "1", "2", "3" } };
		public MasterPage()
		{
			Title = "Master";
			Content = listview;
		}
	}
	public class WebViewPage : ContentPage
	{
		public static WebView webView = new WebView { Source = "https://www.google.com/" };
		public WebViewPage()
		{
			Content = webView;
		}
	}
