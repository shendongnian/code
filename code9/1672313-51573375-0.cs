    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
    
    public partial class App : Xamarin.Forms.Application
    {
		public App ()
		{
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            InitializeComponent();
            MainPage = new NavigationPage(new LoginTabsPage()){
            ...
