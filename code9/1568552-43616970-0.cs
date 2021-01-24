    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //find the gridview in the master page
            GridView gv = Master.FindControl("GridView1") as GridView;
            //add the event to the gridview
            gv.RowDataBound += GridView1Master_RowDataBound;
            gv.DataSource = mySource;
            gv.DataBind();
        }
    }
    protected void GridView1Master_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.BackColor = Color.Red;
        }
    }
