    public bool UserCanUpdate = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(UserCanUpdateAsync));
    }
    private async Task UserCanUpdateAsync()
    {
        var authorizationContext = this.AuthorizationContext();
        UserCanUpdate = await authorizationContext.ConfigurationAuthorization.CanUserUpdateConfig();
    }
