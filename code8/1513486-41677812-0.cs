	private async void saveBtn_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			FileSavePicker fs = new FileSavePicker();
			fs.FileTypeChoices.Add("Image", new List<string>() { ".jpeg" });
			fs.DefaultFileExtension = ".jpeg";
			fs.SuggestedFileName = "Image" + DateTime.Today.ToString();
			fs.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			fs.SuggestedSaveFile = storeFile;
			var s = await fs.PickSaveFileAsync();
			if (s != null)
			{
				using (var dataReader = new DataReader(stream.GetInputStreamAt(0)))
				{
					await dataReader.LoadAsync((uint)stream.Size);
					byte[] buffer = new byte[(int)stream.Size];
					dataReader.ReadBytes(buffer);
					await FileIO.WriteBytesAsync(s, buffer);
				}
			}
		}
		catch (Exception ex) 
		{
			var messageDialog = new MessageDialog("Unable to save now.");
			await messageDialog.ShowAsync();
		}
	}
