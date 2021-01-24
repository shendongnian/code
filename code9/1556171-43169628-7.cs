    context.SavingChanges += OnContextSavingChanges;
    context.SavingChangesAsync += OnContextSavingChangesAsync;
    public void OnContextSavingChanges(object sender, EventArgs e)
    {
      someSyncMethod();
    }
    public async Task OnContextSavingChangesAsync(object sender, EventArgs e)
    {
      await someAsyncMethod();
    }
