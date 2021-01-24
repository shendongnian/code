    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check if it's not a header and footer
        if (e.Row.RowType == DataControlRowType.Row)
        {
            CheckBox chk = new CheckBox();
            chk.AutoPostBack = true;
            // add checked changed event to checkboxes
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            e.Row.Cells[1].Controls.Add(chk); // add checkbox to second column
        }
    }
