    readonly SQLiteAsyncConnection database;
    public CoinsDatabase(string dbPath)
    {
        database = new SQLiteAsyncConnection(dbPath);
        database.CreateTableAsync<Coin>().Wait();
    }
    public Task<List<Coin>> GetCoinsAsync()
    {
        return database.Table<Coin>().ToListAsync();
    }
    public Task<Coin> GetCoinsAsync(int id)
    {
        return database.Table<Coin>().Where(i => i.CoinID == id).FirstOrDefaultAsync();
    }
    public Task<int> SaveCoinAsync(Coin coin)
    {
        if(coin.CoinID == 0){
            return database.InsertAsync(coin);
        } else {
            return database.UpdateAsync(coin);
        }
    }
    public Task<int> DeleteCoinAsync(Coin coin)
    {
        return database.DeleteAsync(coin);
    }
