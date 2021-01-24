    public partial class TutorialPage : ContentPage
    {
        private readonly ITutorialViewModel _dataModel;
        private WebView browser;
        public TutorialPage(ITutorialViewModel dataModel)
        {
            InitializeComponent();
            Title = "Tutorial";
            browser = new WebView() { HeightRequest = 150, WidthRequest = 400, HorizontalOptions = LayoutOptions.CenterAndExpand, IsVisible = false };
            browser.Source = DependencyService.Get<IBaseUrl>().Get();
            browser.Navigated += Browser_Navigated:
            mainStack.Children.Add(browser);
        }
        void Browser_Navigated (object sender, WebNavigatedEventArgs e)
        {
            browser.IsVisible = true;
        }
    }
