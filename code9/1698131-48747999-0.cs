    protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if row is not in edit mode
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dtValues = dtSource;
            // get dropdownlist from gridview
            var ddl = e.Row.FindControl("YourDropDown") as DropDownList;
            if (ddl != null)
            {
                ddl.DataSource = dtValues;
                ddl.DataTextField = "Name"; // add text to dropdownlist
                ddl.DataValueField = "ID"; // add value to dropdownlist
                ddl.DataBind();
                // add default selected value
                ddl.Items.Insert(0, new ListItem("----- Select a Value -----", "0"));
            }
        }
    }
