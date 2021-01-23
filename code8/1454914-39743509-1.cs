    List<string> fileTypeFilter = new List<string>();
    fileTypeFilter.Add(".txt");
    fileTypeFilter.Add(".png");
    var options = new Windows.Storage.Search.QueryOptions(Windows.Storage.Search.CommonFileQuery.OrderByName, fileTypeFilter);
    var query = ApplicationData.Current.LocalFolder.CreateFileQueryWithOptions(options);
    //subscribe on query's ContentsChanged event
    query.ContentsChanged += Query_ContentsChanged;
    var files = await query.GetFilesAsync();
    private void Query_ContentsChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
    {
        //TODO:
    }
