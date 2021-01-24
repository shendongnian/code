    public static readonly Task<int> MyValue = GetMyValue();
    private static async Task<int> GetMyValue()
    {
        return await GetItFromWherever();
    }
