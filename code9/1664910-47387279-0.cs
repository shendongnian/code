    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chk = (CheckBox)e.Row.Cells[1].Controls[0];
            chk.Visible = false;
            e.Row.Cells[1].Text = chk.Checked.ToString();
        }
    }
