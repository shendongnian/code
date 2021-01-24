    StorageFileQueryResult fileQuery;
    
    async void CreateWatchFolder(StorageFolder folder)
        {
            var options = new QueryOptions();
            options.FolderDepth = FolderDepth.Deep;
            fileQuery = folder.CreateFileQueryWithOptions(options);
            _fileQuery.ContentsChanged += OnContentsChanged;
            var files = await _fileQuery.GetFilesAsync();
        }
        
        async void OnContentsChanged(IStorageQueryResultBase sender, object args)
        {
            // Do stuff, e.g. check for changes
        }
