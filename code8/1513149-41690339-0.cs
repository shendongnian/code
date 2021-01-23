        CoreDispatcher dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        private void InitTimer()
        {
            dispatchTimer = new DispatcherTimer();
            dispatchTimer.Interval = new TimeSpan(0, 0, 1);
            dispatchTimer.Tick += (object sender, object e) =>
            {
                Debug.WriteLine("Timer tick.");
            };
            dispatchTimer.Start();
        }
        private void InitGpio()
        {
            button = GpioController.GetDefault().OpenPin(4);
            button.DebounceTimeout = new TimeSpan(0, 0, 0, 0, 200);
            button.ValueChanged += BtnPin_ValueChanged;
        }
        private async void BtnPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                Debug.WriteLine("Button pressed");
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                 {
                     dispatchTimer.Stop();
                 }
                );
            }
            else
            {
                Debug.WriteLine("Button released");
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    dispatchTimer.Start();
                }
                );
            }
        }
