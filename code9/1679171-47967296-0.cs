    public async Task ShowCards(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await PickCard();
        }
    }
