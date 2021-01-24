    protected void Page_Load(object sender, EventArgs e)
      {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
               //User session active
            }
        }
        else
        {
            //User session not active
            Response.Redirect("Login.aspx", false);
        }
    }
