        public static IRandomAccessStream stream = null;
        public StorageFile file = null;
        public async void GetMedia()
        {
            var openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            file = await openPicker.PickSingleFileAsync();
            stream = await file.OpenAsync(FileAccessMode.Read);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                MediaData mediaData = new MediaData();
                mediaData.stream = stream;
                mediaData.file = file;
                frame.Navigate(typeof(NewWindowPage), mediaData);
                Window.Current.Content = frame;
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetMedia();
        }
