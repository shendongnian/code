        private bool initializing = true;
        public MainPage()
        {
            this.InitializeComponent();
            toggleSwitchPushNotifications.IsOn = Convert.ToBoolean(App.localSettings.Values["PushNotifications"]);
            toggleSwitchFullScreen.IsOn = Convert.ToBoolean(App.localSettings.Values["FullScreen"]);
            toggleSwitchDataCollecting.IsOn = Convert.ToBoolean(App.localSettings.Values["DataCollecting"]);
            toggleSwitchTest.IsOn = Convert.ToBoolean(App.localSettings.Values["Test"]);
            initializing = false;
        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (initializing) return;
            App.localSettings.Values["PushNotifications"] = toggleSwitchPushNotifications.IsOn;
            App.localSettings.Values["FullScreen"] = toggleSwitchFullScreen.IsOn;
            App.localSettings.Values["DataCollecting"] = toggleSwitchDataCollecting.IsOn;
            App.localSettings.Values["Test"] = toggleSwitchTest.IsOn;
        }
