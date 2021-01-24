    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostback)
        {
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
