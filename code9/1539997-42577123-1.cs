        private void WiFiInformationUpdated(object sender, WiFiInformationEventArgs args)
        {
            if (args.SSID != _viewModel.WifiInformationData.SSID)
            {
                _viewModel.WifiInformationData.SSID = args.SSID;
            }
            if (args.SignalBars != _viewModel.WifiInformationData.SignalBars)
            {
                _viewModel.WifiInformationData.SignalBars = args.SignalBars;
            }
            if(args.Picture != null)
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,() =>
                {
                    var pic = new BitmapImage(args.Picture);
                    _viewModel.WifiInformationData.Picture = pic;
                    Image img = DataTemplateObjects.FindChildControl<Image>(commandBar, "imgWifi") as Image;
                    if (img == null) return;
                    img.Source = pic;
                });
            }
        }
