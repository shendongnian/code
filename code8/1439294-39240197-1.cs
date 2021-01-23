    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool _IspreviousBtnEnable;
    
        public bool IspreviousBtnEnable
        {
            get { return _IspreviousBtnEnable; }
            set
            {
                if (value != _IspreviousBtnEnable)
                {
                    _IspreviousBtnEnable = value;
                    OnPropertyChanged();
                }
            }
        }
    
        private bool _IsnextBtnEnable;
    
        public bool IsnextBtnEnable
        {
            get { return _IsnextBtnEnable; }
            set
            {
                if (value != _IsnextBtnEnable)
                {
                    _IsnextBtnEnable = value;
                    OnPropertyChanged();
                }
            }
        }
    
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        private void previousBtn_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoBack)
                webView.GoBack();
        }
    
        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoForward)
                webView.GoForward();
        }
    
        private void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (webView.CanGoForward)
                IsnextBtnEnable = true;
            else
                IsnextBtnEnable = false;
    
            if (webView.CanGoBack)
                IspreviousBtnEnable = true;
            else
                IspreviousBtnEnable = false;
        }
    }
