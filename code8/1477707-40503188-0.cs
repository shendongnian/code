    public async Task<Banana> PeelBanana(Banana banana)
    {
        _tenant.OnPeelBanana(banana);
        banana.FinishPeeling();
        return banana;
    }
