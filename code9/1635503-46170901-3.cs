    public static async Task<CustomViewModel> Create()
    {
        var data = await FetchAsyncData();
        return new CustomViewModel(data);
    }
