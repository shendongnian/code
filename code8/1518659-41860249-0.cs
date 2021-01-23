    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //this works
            gvDocSchedule.DataSource = Common.LoadFromDB();
            gvDocSchedule.DataBind();
        }
        //this does not
        gvDocSchedule.DataSource = Common.LoadFromDB();
        gvDocSchedule.DataBind();
    }
