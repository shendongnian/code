        public MainPage()
        {
            this.InitializeComponent();
            toggleSwitchPushNotifications.IsOn = Convert.ToBoolean(App.localSettings.Values["PushNotifications"]);
            toggleSwitchFullScreen.IsOn = Convert.ToBoolean(App.localSettings.Values["FullScreen"]);
            toggleSwitchDataCollecting.IsOn = Convert.ToBoolean(App.localSettings.Values["DataCollecting"]);
            toggleSwitchTest.IsOn = Convert.ToBoolean(App.localSettings.Values["Test"]);
        }
        private void ToggleSwitchFullScreen_OnToggled(object sender, RoutedEventArgs e)
        {
            App.localSettings.Values["FullScreen"] = toggleSwitchFullScreen.IsOn;
        }
        private void ToggleSwitchDataCollecting_OnToggled(object sender, RoutedEventArgs e)
        {
            App.localSettings.Values["DataCollecting"] = toggleSwitchDataCollecting.IsOn;
        }
        private void ToggleSwitchTest_OnToggled(object sender, RoutedEventArgs e)
        {
            App.localSettings.Values["Test"] = toggleSwitchTest.IsOn;
        }
        private void ToggleSwitchPushNotifications_OnToggled(object sender, RoutedEventArgs e)
        {
            App.localSettings.Values["PushNotifications"] = toggleSwitchPushNotifications.IsOn;
        }
