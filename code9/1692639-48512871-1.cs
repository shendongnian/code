	public async void SaveImage(string filepath)
	{
		// First, check to see if we have initially asked the user for permission 
		// to access their photo album.
		if (Photos.PHPhotoLibrary.AuthorizationStatus == 
            Photos.PHAuthorizationStatus.NotDetermined)
		{
			var status = 
                await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync(
				    Plugin.Permissions.Abstractions.Permission.Photos);
		}
		
		if (Photos.PHPhotoLibrary.AuthorizationStatus == 
            Photos.PHAuthorizationStatus.Authorized)
		{
			// We have permission to access their photo album, 
            // so we can go ahead and save the image.
			var imageData = System.IO.File.ReadAllBytes(filepath);
			var myImage = new UIImage(NSData.FromArray(imageData));
			myImage.SaveToPhotosAlbum((image, error) =>
			{
				if (error != null)
					System.Diagnostics.Debug.WriteLine(error.ToString());
			});
		}
	}
	
