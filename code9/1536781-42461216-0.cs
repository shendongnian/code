    public MainPage()
            {
                this.InitializeComponent();
    
                if ((string)ApplicationData.Current.LocalSettings.Values["BGColor"] == "Red")
                    LayoutRoot.Background = new SolidColorBrush(Colors.Red);
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ApplicationData.Current.LocalSettings.Values["BGColor"] = "Red";
                LayoutRoot.Background = new SolidColorBrush(Colors.Red);
            }
