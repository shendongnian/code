    Type t = Type.GetTypeFromProgID("Microsoft.Update.Session", 
    UpdateSession UpdateSession = (UpdateSession)Activator.CreateInstance(
    IUpdateSearcher UpdateSearchResult = UpdateSession.CreateUpdateSearcher();
    UpdateSearchResult.Online = true;
    ISearchResult SearchResults = UpdateSearchResult.Search("IsInstalled=1 AND IsPresent=1");
