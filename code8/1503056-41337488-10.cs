    async Task SaveImageToDatabase(byte[] downloadedImage, string imageUrl)
    {
       var downloadedImageBase64String = Convert.ToBase64String(downloadedImage);
       var downloadedImageModel = new DownloadedImageModel
	   {
	       ImageUrl = imageUrl,
	       DownloadedImageAsBase64String = downloadedImageBase64String
	   };
       await App.Database.SaveDownloadedImage(downloadedImageModel);
    }
...
    async Task SaveDownloadedImage(DownloadedImageModel downloadedImage)
	{
		await Task.Run(async () =>
		{
			if (await GetDownloadedImageAsync(downloadedImage.ImageUrl) != null)
			{
				lock (_locker)
				{
					_database.Update(downloadedImage);
				}
			}
			else 
            {
				lock (_locker)
				{
					_database.Insert(downloadedImage);
				}
			}
		});
	}
