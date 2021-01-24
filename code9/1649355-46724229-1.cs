    public AnnouncementPage()
        {
            InitializeComponent();
            BindWebViewControl();
        }
    
        protected override void OnAppearing()
        {
            stkWebview.IsVisible = false;
            stkLoading.IsVisible = true;
        }
        private async void BindWebViewControl()
        {            
            var result = await _dataService.GetAnnouncement();
            webcontentcontrol.Source = result.Data.First().WebViewSource;
            stkWebview.IsVisible = true;
            stkLoading.IsVisible = false;
        }  
