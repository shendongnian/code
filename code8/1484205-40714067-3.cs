    public async Task<string> GetData(int id)
    {
        string inp =  await CommonMethod(id);
        return inp;
    }
