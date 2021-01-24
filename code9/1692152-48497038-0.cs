    async Task<MyResult> GetMyData(...)
    {
        Task<SomeData> taskGetData = GetDataFromCloud(...);
         // while the data is being fetched, we can continue working
         DoSomethingElse();
         // now we need the data:
         SomeData fetchedData = await taskGetData;
         MyResult result = ProcessFetchedData(fetchedData);
         return result;
    }
