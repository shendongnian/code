    public override void Dispose()
    {
        if (markupManager != null) {
            markupManager.Dispose();
            markupManager = null;
        }
    }
