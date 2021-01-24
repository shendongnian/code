    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //check if the row is in edit mode
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //find the dropdownlist in the row using findcontrol
                DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList");
                //fill the dropdownlist from code behind if needed
                ddl.DataSource = source;
                ddl.DataTextField = "key";
                ddl.DataValueField = "valee";
                ddl.DataBind();
                //cast the dataitem back to a datarowview
                DataRowView row = e.Row.DataItem as DataRowView;
                //set the correct listitem as selected
                ddl.SelectedValue = row["myValue"].ToString();
            }
        }
    }
