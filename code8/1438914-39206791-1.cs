    public override async Task ExecutePostProcessingAsync()
    {
        await resizer.ScaleImageAsync();
        await base.ExecutePostProcessingAsync();
    }
