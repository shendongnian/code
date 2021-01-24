    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        lbUserID.Text = Context.User.Identity.Name;
        UpdateProgress1.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;
        lbLocalTime.Text = DateTime.Now.ToLongDateString();
        if (!this.IsPostBack)
        {
            
            /*FOR TIMEOUT PURPOSE*/
            Session["Reset"] = true;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            //int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            int timeout = GetSessionTimeout();
            ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
            /*ENDS TIME OUT*/
        }
    }
    [WebMethod(EnableSession = true)]
    public static int ResetSession()
    {
        HttpContext.Current.Session["Reset"] = true;
        int timeout = GetSessionTimeout();
        return timeout;
    }
    private static int GetSessionTimeout()
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
        SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
        return Convert.ToInt32(section.Timeout.TotalMinutes * 1000 * 60);
    }
