    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Row)
        {
            DropDownList ddl = new DropDownList();
            ddl.AutoPostBack = true;
            // add index changed events to dropdownlists
            ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            e.Row.Cells[1].Controls.Add(ddl); // add dropdownlist to column two
        }
    }
