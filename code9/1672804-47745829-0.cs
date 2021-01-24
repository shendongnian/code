        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var pirS1 = new PirSensor(17, PirSensor.SensorType.ActiveHigh);
            pirS1.motionDetected += new EventHandler<Windows.Devices.Gpio.GpioPinValueChangedEventArgs>(OnPirSensor1MotionDetected);
            var pirS2 = new PirSensor(27, PirSensor.SensorType.ActiveHigh);
            pirS2.motionDetected += new EventHandler<Windows.Devices.Gpio.GpioPinValueChangedEventArgs>(OnPirSensor2MotionDetected);
        }
        private async void OnPirSensor1MotionDetected(object sender, Windows.Devices.Gpio.GpioPinValueChangedEventArgs earg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    // Your UI update code goes here!
                    pirSensorVal1.Text = earg.Edge.ToString();
                });
        }
        private async void OnPirSensor2MotionDetected(object sender, Windows.Devices.Gpio.GpioPinValueChangedEventArgs earg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    // Your UI update code goes here!
                    pirSensorVal2.Text = earg.Edge.ToString();
                });            
        }
