    public async Task<DataContext> GetDataAsync()
    {
        DataContext dac1 = new DataContext();
        var t1 = dac1.GetProductsAsync();
        DataContext dac2 = new DataContext();
        var t2 = dac2.GetProducts2Async();
        DataContext dac3 = new DataContext();
        var t3 = dac3.GetProducts3Async();
        DataContext dac4 = new DataContext();
        var t4 = dac4.GetProducts4Async();
        DataContext dac5 = new DataContext();
        var t5 = dac5.GetProducts5Async();
        data.items1 = await t1;
        data.items2 = await t2;
        data.items3 = await t3;
        data.items4 = await t4;
        data.items5 = await t5;
        // dispose all data contexts
        return data;
    }
