	using (WebClient webClient = new WebClient())
	{
		string filename = "SOMEFILENAME";
		string extension = ".png"; // or whatever is the extension
	
		byte[] data = webClient.DownloadData(imageUrl);
		Stream memoryStream = new MemoryStream(data);
		var options = new Sitecore.Resources.Media.MediaCreatorOptions
		{
			FileBased = false,
			OverwriteExisting = true,
			Versioned = true,
			IncludeExtensionInItemName = true,
			Destination = Factory.GetDatabase("master").GetItem(Settings.GetSetting("ProfilePicturesFolderItemId")).Paths.Path + "/" + filename,
			Database = Factory.GetDatabase("master"),
			AlternateText = userProfileItem.Name
		};
		using (new SecurityDisabler())
		{
			var creator = new Sitecore.Resources.Media.MediaCreator();
			creator.CreateFromStream(memoryStream, filename + extension, options);
		}
	}
