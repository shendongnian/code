    public void Search(string searchKey, Action<SearchResults> callback)
    {
       ....
       LyncClient.GetClient().ContactManager.BeginSearch(
                 searchKey,
                 (ar) =>
                 {
                     SearchResults searchResults = LyncClient.GetClient().ContactManager.EndSearch(ar);
                     callback(searchResults);
                 });
       ....
    }
