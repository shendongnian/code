    private void OnPageLoad(object sender, RoutedEventArgs e)
            {
                PowerManager.BatteryStatusChanged += OnBatteryStatusChanged;
            }
    
            private async void OnBatteryStatusChanged(object sender, object e)
            {
                var bs = PowerManager.BatteryStatus;
    
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var dischargeTime = PowerManager.RemainingDischargeTime;
                    this.batteryProgress.Value = PowerManager.RemainingChargePercent;
                    this.batteryProgressPercentage.Text = PowerManager.RemainingChargePercent + " % remaining";
                    this.batteryStatus.Text = "Battery Level: " + bs;
                    this.batteryDischargeTime.Text = "Battery Left: " + dischargeTime.Hours + " hours " + dischargeTime.Minutes + " minutes " + dischargeTime.Seconds + " seconds";
                });
            }
