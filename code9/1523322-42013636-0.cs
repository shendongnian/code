    public ICommand ReloadCommand
    {
        get
        {
            return new MvxCommand<XXXType>(async (xxx) =>
                {
                    await RefreshRoutesList(xxx);
                });
        }
    }
