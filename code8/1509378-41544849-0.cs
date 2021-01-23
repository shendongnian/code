	public class PlayPage : ContentPage
	{
		protected override void OnAppearing()
		{
			System.Diagnostics.Debug.WriteLine("PlayPage");
			base.OnAppearing();
		}
	}
	public class AboutPage : ContentPage
	{
		protected override void OnAppearing()
		{
			System.Diagnostics.Debug.WriteLine("AboutPage");
			base.OnAppearing();
		}
	}
	public class SettingsPage : ContentPage
	{
		protected override void OnAppearing()
		{
			System.Diagnostics.Debug.WriteLine("SettingPage");
			base.OnAppearing();
		}
	}
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			var playPage = new PlayPage() { Title = "Play" };
			var settingsPage = new SettingsPage() { Title = "Settings" };
			var aboutPage = new AboutPage() { Title = "About" };
			Children.Add(playPage);
			Children.Add(settingsPage);
			Children.Add(aboutPage);
		}
	}
	public class App : Application
	{
		public App()
		{
			this.MainPage = new MainPage(); 
		}
	}
