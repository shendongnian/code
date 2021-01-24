    public async void ImageViewGenerateAsync () {
	var ImagesFolder = await StorageApplicationPermissions.
                              FutureAccessList.GetFolderAsync("FolderFoken");
	
    var ImgFiles = await ImagesFolder.GetFilesAsync();
	foreach( StorageFile file in ImgFiles ) {
		if (file != null ) {
			try {
				var filestream = await file.OpenAsync(FileAccessMode.Read);
				var img = new BitmapImage();
				await img.SetSourceAsync (filestream);
				PrivateSet_images.Add(img);
			}
			catch ( Exception ) {							
			}
		}
	}
