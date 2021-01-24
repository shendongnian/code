    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if your row is not a Header/Footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get Dropdownlist from gridview
            DropDownList DropDownList1x = e.Row.FindControl("DropDownList1x") as DropDownList;
            // ddlouter is your outside DropDownList
            DropDownList1x.Items.FindByValue(ddlOuter.SelectedValue).Selected = true; 
        }
    }
