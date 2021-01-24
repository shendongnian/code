    public async Task<DataType> GetData()
    {
        var address = "XXX";
        var res = await Client.GetAsync(address).ConfigureAwait(false);
        var data = await res.Content.ReadAsStringAsync();
        return data;
    }
