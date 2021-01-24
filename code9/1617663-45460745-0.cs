    public const string ReturnUrlHash = "returnUrlHash";
    protected void OnLoggedIn(object sender, EventArgs e)
    {
        string returnUrl = Request.QueryString["ReturnUrl"];
        if (!string.IsNullOrEmpty(returnUrl))
        {
            if (Request.Form.AllKeys.Contains(ReturnUrlHash))
            {
                returnUrl += Request.Form[ReturnUrlHash];
            }
            Response.Redirect(returnUrl);
        }
    }
