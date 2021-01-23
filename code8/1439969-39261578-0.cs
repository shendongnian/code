    public async Task LoadAsync()
    {
        await Task.WhenAll(
            LoadProp1Async(),
            LoadProp2Async()
        );
    }
    private async Task LoadProp1Async()
    {
      Prop1 = await repo.GetProp1ByIDAsync(ID);
    }
    private async Task LoadProp2Async()
    {
      Prop2 = await repo.GetProp2ByIDAsync(ID);
    }
