    public MainPage() {
    
        this.InitializeComponent();
        Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
        this.Loaded += OnLoaded;
     
    }
    
    public async void OnLoaded(object sender, RoutedEventArgs e) {
        responseBlockTxt.Text = await start();
    }
    
    public async Task<string> start() {
        var response = await sendRequest();
    
        System.Diagnostics.Debug.WriteLine(response);
    
        return response;
    }
    
    public async Task<string> sendRequest() {
        using (var client = new HttpClient()) {
            var values = new Dictionary<string, string>
            {
                { "vote", "true" },
                { "slug", "the-slug" }
            };
    
            var content = new FormUrlEncodedContent(values);
    
            var response = await client.PostAsync("URL/api.php", content);
    
            var responseString = await response.Content.ReadAsStringAsync();
    
            return responseString;
        }    
    }
