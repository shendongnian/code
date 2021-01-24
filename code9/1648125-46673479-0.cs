    protected void Page_Load(object sender, EventArgs e)
    {
        fillGrid.DataSource = table;
        if(!IsPostBack)
            fillGrid.DataBind();
    }
    protected void fillGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        fillGrid.EditIndex = e.NewEditIndex;
        fillGrid.DataBind();
    }       
    protected void fillGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string desc = ((TextBox)(fillGrid.Rows[e.RowIndex].FindControl("descTb"))).Text;
    }
