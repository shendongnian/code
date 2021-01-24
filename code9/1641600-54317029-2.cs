    private async void connectWiFi_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var picker = new FileOpenPicker();
        picker.ViewMode = PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        picker.FileTypeFilter.Add(".txt");
        StorageFile file = await picker.PickSingleFileAsync();
        if (file != null)
        {
			bool success = false;
			string _line;
			using (var inputStream = await file.OpenReadAsync())
			using (var classicStream = inputStream.AsStreamForRead())
			using (var streamReader = new StreamReader(classicStream))
			{
				while (!streamReader.EndOfStream)
				{
					_line = streamReader.ReadLine();
					setConnectionStatus("Status: Checking WiFi network using passphrase " + _line);
					if (await checkWifiPassword(_line) == true)
					{
						success = true;
						setConnectionStatus("SUCCESS: Password successfully identified as " + _line);
						firstAdapter.Disconnect();
						var msg = new MessageDialog(connectionStatus.Text);
						await msg.ShowAsync();
						break;
					}
					else
					{
						setConnectionStatus("FAIL: Password " + _line + "is incorrect. Checking next password...");
					}
				}
			}
			if(!success){ /* report to the user*/ }
        }
