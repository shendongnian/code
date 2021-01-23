    public **partial** class launcher5Page : ContentPage
    {
        public launcher5Page()
        {
            InitializeComponent();
    
            webview1.Source = "web address here";
        }
    
        public **static** bool changeURL(string urlString)
        {
            **webview1**.Source = urlString;
            return true;
        }
    }
