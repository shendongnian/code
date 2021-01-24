    public async Task<bool> CreateFileAsync(string name, string context)
	{
	    // get hold of the file system
		IFolder folder = FileSystem.Current.LocalStorage;
		// create a file, overwriting any existing file
		IFile file = await folder.CreateFileAsync(name, 
                                                  CreationCollisionOption.ReplaceExisting);
		// populate the file with some text
		await file.WriteAllTextAsync(context);
		return true;
	}
