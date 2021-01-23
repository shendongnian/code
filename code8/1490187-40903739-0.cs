    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated) 
        {
            // User is logged in, continue
        }
        else
        {
            //Invalid login...
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
