    protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = DbUtilities.GetDataTableFromSqlQuery("select top 10 * from Users");
            GridView1.DataBind();
        }
        
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.FooterRow;
    
            var firstName = ((DropDownList)row.Cells[1].FindControl("ddlCName")).SelectedValue;
            var s = firstName;
        }
