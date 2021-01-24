    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //create a dropdownlist and assign an ID
            DropDownList DDL1 = new DropDownList();
            DDL1.ID = "DDL1";
            //add some dummy listitems
            DDL1.Items.Insert(0, new ListItem() { Text = "A", Value = "A" });
            DDL1.Items.Insert(1, new ListItem() { Text = "B", Value = "B" });
            DDL1.Items.Insert(2, new ListItem() { Text = "C", Value = "C" });
            //add the control to the row
            e.Row.Cells[0].Controls.Add(DDL1);
        }
    }
