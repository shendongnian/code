    private static List<MyModel> MyModelInternal;
    public static async Task<List<MyModel>> GetMyModelAsync()
    {
        if (MyModelInternal == null)
        {
            MyModelInternal = await MyHelper.GetCacheAsync();
        }
        return Task.FromResult(MyModelInternal);
    }
