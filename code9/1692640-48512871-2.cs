	public async void SaveImage(string filepath)
	{
		var imageData = System.IO.File.ReadAllBytes(filepath);
		var filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
		
		if (Device.Idiom == TargetIdiom.Desktop)
		{
			var savePicker = new Windows.Storage.Pickers.FileSavePicker();
			savePicker.SuggestedStartLocation = 
				Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
			savePicker.SuggestedFileName = filename;
			savePicker.FileTypeChoices.Add("JPEG Image", new List<string>() { ".jpg" });
			var file = await savePicker.PickSaveFileAsync();
			if (file != null)
			{
				CachedFileManager.DeferUpdates(file);
				await FileIO.WriteBytesAsync(file, imageData);
				var status = await CachedFileManager.CompleteUpdatesAsync(file);
				if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
					System.Diagnostics.Debug.WriteLine("Saved successfully"));
			}
		}
		else
		{
			StorageFolder storageFolder = KnownFolders.SavedPictures;
			StorageFile sampleFile = await storageFolder.CreateFileAsync(
				filename + ".jpg", CreationCollisionOption.ReplaceExisting);
			await FileIO.WriteBytesAsync(sampleFile, imageData);
		}
	}
