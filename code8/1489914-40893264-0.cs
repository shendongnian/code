    public async Task<CustomViewModel> GetCustomViewModel()
    {
        CustomViewModel myViewModel = await GetFromDb();
        return myViwModel;
    }
