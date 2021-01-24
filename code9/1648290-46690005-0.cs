    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList ddlMeasure = e.Row.FindControl("ddlMeasure") as DropDownList;
            if (ddlMeasure != null)
            {
                ddlMeasure.Items.Insert(0, new ListItem("DLL Found!", "-1"));
            }
        }
    }
