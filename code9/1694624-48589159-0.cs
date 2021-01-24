    private MvxInteraction _interaction = new MvxInteraction();
    public IMvxInteraction MyMvxInteraction => _interaction;
    public override async Task Initialize()
    {
        ClientID = await MyDataSource.GetClientID();
        this._interaction.Raise();
    }
