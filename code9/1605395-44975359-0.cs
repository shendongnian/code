    public void InitAndStartExtensions()
    {
        foreach (Extension extension in GetEnabledExtensionList())
        {
            Task.Run(() =>
            {
                extension.Init();
                extension.Start();
            });
        }
    }
