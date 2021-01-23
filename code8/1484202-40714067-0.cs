    public async Task<string> GetData(int id)
    {
        Task<string> inp =  CommonMethod(id);
        return inp;
    }
