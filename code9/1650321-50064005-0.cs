    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new CryptoCoinsMap(modelBuilder.Entity<CoinMaster>());
        new CoinQuotesDailyMap(modelBuilder.Entity<CoinQuotesDaily>());
    }
