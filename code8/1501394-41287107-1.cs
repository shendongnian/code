    protected override void InitializeLastChance()
    {
        base.InitializeLastChance();
        Mvx.RegisterSingleton<IMvxMessenger>(new MvxMessengerHub());
    }
