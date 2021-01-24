    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string[] Gender = { "Male", "Female" };
            DdlGender.DataSource = Gender;
            DdlGender.DataBind();
            string[] Update = { "Yes", "No" };
            DdlUpdates.DataSource = Update;
            DdlUpdates.DataBind();
        }
    }
