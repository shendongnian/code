    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if its not a header or footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // check if its in a EditTemplate
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                TextBox txt = e.Row.FindControl("TextBox1") as TextBox;
                string name = txt.Text;
            }
        }
    }
