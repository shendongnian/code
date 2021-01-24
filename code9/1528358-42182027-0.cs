    protected void gvComponentLocks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //create a new dropdownlsit
            DropDownList ddl = new DropDownList();
            //bind the source and define the values
            ddl.DataSource = getComponentsAndLocks(worksPermitID);
            ddl.DataTextField = "columnA";
            ddl.DataValueField = "columnB";
            ddl.DataBind();
            //add the dropdownlist to the gridview in column 1
            e.Row.Cells[1].Controls.Add(ddl);
        }
    }
