    // AuthorizationCallback.aspx.cs
    protected void Page_Load (object sender, EventArgs e) {
        // Needed in order to process ValidateIdentityTokenAsync below
        RegisterAsyncTask(new PageAsyncTask(ProcessRequest));
    }
    private async Task ProcessRequest () {
        var idToken = Request.Form["id_token"];
        ...
        var claims = await ValidateIdentityTokenAsync(idToken, state);
        ...
    }
