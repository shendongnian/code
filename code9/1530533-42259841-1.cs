	[Activity(Label = "OpenPage.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			var page = Intent.GetStringExtra("page");
			LoadApplication(new App(page));
		}
	}
