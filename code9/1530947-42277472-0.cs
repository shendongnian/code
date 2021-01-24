    private async void PostStreamButton_OnClick(object sender, RoutedEventArgs e) {
        using (var client = new HttpClient()) {
            var dummyBuffer = new UnicodeEncoding().GetBytes("this is dummy stream");
            var dummyStream = new MemoryStream(dummyBuffer).AsRandomAccessStream().AsStream();
            var inputData = new StreamContent(dummyStream);
            
            var response = await client.PostAsync("url", inputData);
        }
    }
