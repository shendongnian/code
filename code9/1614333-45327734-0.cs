    public async Task<bool> SaveCache(Stream data, string id)
    {
        try
        {
            //cache folder in local storage
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            var folder = await rootFolder.CreateFolderAsync("Cache",
            CreationCollisionOption.OpenIfExists);
    		
            //save cached data
            IFile file = await folder.CreateFileAsync(id + ".png", CreationCollisionOption.ReplaceExisting);
            byte[] buffer = new byte[data.Length];
    		
    		//make sure stream is at beginning of data, then read data into buffer
    		data.Seek(0, SeekOrigin.Begin);
            data.Read(buffer, 0, buffer.Length);
            using (Stream stream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                stream.Write(buffer, 0, buffer.Length);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
