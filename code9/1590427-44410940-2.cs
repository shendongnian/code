    protected void Page_Load(object sender, EventArgs e)
    {
        if(!User.IsInRole("A"))
        {
               Response.Redirect("~/NewPage.aspx");
        }
    }
