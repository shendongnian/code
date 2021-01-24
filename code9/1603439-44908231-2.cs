    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chbEdit = (CheckBox)e.Row.FindControl("CheckBoxEditable");
            string value = ((Label)e.Row.FindControl("lblID")).Text;
            if (value=="True")
                chbEdit.Checked = true;
            else
                chbEdit.Checked = false;
        }
    }
