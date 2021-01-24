	public async Task<string> GetUserIdAsync()
	{
		var fileName = "user_id";
		var folder = ApplicationData.Current.RoamingFolder;
		var file = await folder.TryGetItemAsync(fileName);
		if (file == null)
		{
			//if file does not exist we create a new guid
			var storageFile = await folder.CreateFileAsync(fileName);
			var newId = Guid.NewGuid().ToString();
			await FileIO.WriteTextAsync(storageFile, newId);
			return newId;
		}
		else
		{
			//else we return the already exising guid
			var storageFile = await folder.GetFileAsync(fileName);
			return await FileIO.ReadTextAsync(storageFile);
		}
	}
