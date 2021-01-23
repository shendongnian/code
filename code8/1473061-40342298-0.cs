    // LocalCacheController
    void GetUncachedRecordIDs<T>(Action<List<int>> action)
    {
        // ...
        if (!cached) {
            action(recordIds);
        }
    }
    
    // ...
    
    public static void CacheUncachedMessageIDs(List<int> messageIDs)
    {
        LocalCacheController.GetUncachedRecordIDs<PrivateMessage>(messageIDs, uncachedRecordIDs => {
            using (var db = new DBContext())
            {
                 // ...
            }
        });    
}
