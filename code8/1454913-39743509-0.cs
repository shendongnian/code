    List<string> fileTypeFilter = new List<string>();
    fileTypeFilter.Add(".txt");
    fileTypeFilter.Add(".png");
    var options = new Windows.Storage.Search.QueryOptions(Windows.Storage.Search.CommonFileQuery.OrderByName, fileTypeFilter);
    var quey = ApplicationData.Current.LocalFolder.CreateFileQueryWithOptions(options);
    //subscribe on query's ContentsChanged event
    quey.ContentsChanged += Quey_ContentsChanged;
    var files = await quey.GetFilesAsync();
    private void Quey_ContentsChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
    {
        //TODO:
    }
