    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && !Page.IsPostBack)
        {
            DropDownList ddlMap = (e.Row.FindControl("DropDownList1") as DropDownList);
            DataTable dt = new DataTable();
            dt = (DataTable)Session["data"];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ddlMap.Items.Add(dt.Columns[i].Caption.ToString());
            }
            ddlMap.Items.Insert(0, new ListItem("Ignore"));
        }
    }
