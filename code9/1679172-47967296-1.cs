    public async Task ShowCards(CancellationToken ct)
    {
        while (true)
        {
            ct.ThrowIfCancellationRequested();
            await PickCard();
        }
    }
