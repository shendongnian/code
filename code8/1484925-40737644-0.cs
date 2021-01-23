    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow 
                   && GridView1.EditIndex == e.Row.RowIndex)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList2");
            string val = ddl.SelectedValue.ToString();
            SqlDataSource1.SelectParameters.Add("CHECKEDIN", val);
        }
    }
