    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this works
            gvDocSchedule.DataSource = LoadFromDB();
            gvDocSchedule.DataBind();
        }
        //this does not
        gvDocSchedule.DataSource = LoadFromDB();
        gvDocSchedule.DataBind();
    }
