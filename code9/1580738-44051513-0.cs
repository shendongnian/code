    public async Task<byte[]> GetPhotoBytes(string fileName)
    {
        var localStorage = FileSystem.Current.LocalStorage;
        var folderExists = await localStorage.CheckExistsAsync(PhotosFolder);
    
        if (!folderExists.Equals(ExistenceCheckResult.FolderExists))
        {
            return null;
        }
    
        var localStorageFolder = await localStorage.GetFolderAsync(PhotosFolder);
        var fileExists = await localStorageFolder.CheckExistsAsync(fileName);
    
        if (!fileExists.Equals(ExistenceCheckResult.FileExists))
        {
            return null;
        }
    
        IFile file = await localStorageFolder.GetFileAsync(fileName);
    
        if (file == null)
        {
            return null;
        }
    
        var stream = await file.OpenAsync(FileAccess.Read);
    
        byte[] bytes = null;
        using (var memoryStream = new System.IO.MemoryStream())
        {
            stream.CopyTo(memoryStream);
            stream.Dispose();
            bytes = memoryStream.ToArray();
        }
    
        return bytes;
    
    }
