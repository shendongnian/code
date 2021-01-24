    public TrendingShowsDetails(string videolink)
            {
                InitializeComponent();
    
                loadVideo_wv.Source = "https://www.youtube.com/playlist?list=" + videolink;
    
            }
    
    
            protected async override void OnAppearing()
            {
                base.OnAppearing();
                await activity_indicator.ProgressTo(0.9, 900, Easing.SpringIn);
    
            }
    
            public void OnNavigating(object sender, WebNavigatingEventArgs e)
            {
                activity_indicator.IsVisible = true;
          
    
            }
    
            public void OnNavigated(object sender, WebNavigatedEventArgs e)
            {
    
                activity_indicator.IsVisible = false;
            
            }
