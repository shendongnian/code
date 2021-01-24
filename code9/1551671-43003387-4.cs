    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = row.FindControl("DropDownListItem") as DropDownList;
                ddl.DataSource = Common.LoadFromDB();
                ddl.DataTextField = "field01";
                ddl.DataValueField = "itemID";
                ddl.DataBind();
            }
        }
    }
