    protected void gv_DataBound(object sender, GridViewRowEventArgs e)
    {
        // Get this row's CheckBox control
        CheckBox chkSelector = (CheckBox)e.Row.FindControl("chk_selection");
        // Cast the database boolean value and set the checkbox's Checked property
        chkSelector.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "bool_field"));
    }
    protected void chk_selection__CheckedChanged(object sender, EventArgs e)
    {
        // Update your database
    }
