    private static Random _randomizer = new Random();
    
    public async Task CreateFileAsync()
    {        
        var random = 0;
        lock ( _randomizer )
        {
           random = _randomizer.Next();
        }
        var myFolder = await GetFolder("MyFolderName");
        var fileName = $"{random}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";
        var myFile = await myFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(myFile, "some content");
        async Task<StorageFolder> GetFolder(string folderName)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
    
            var possibleFolder = await storageFolder.TryGetItemAsync(folderName);
            if (possibleFolder == null)
            {
                await storageFolder.CreateFolderAsync(folderName);
            }
    
            var folder = await storageFolder.GetFolderAsync(folderName);
    
            return folder;
        }            
    }
