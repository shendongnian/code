    public static async Task<VideoOperationResult> testEmotionApi()
    {
        // everything here the same, except...
        return operationResult;
    }
    
    public async Task callEmotionTestApi()
    {
        VideoOperationResult result = await testEmotionApi();
        ...
    }
