    var filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
    filter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
    filter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
    
    var httpClient = new Windows.Web.Http.HttpClient(filter);
    
    var response = await httpClient.GetAsync(new Uri("LINK_TO_AZURE_FILE_STORAGE_IMAGE"));
