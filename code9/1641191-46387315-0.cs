    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex < 0) return;
        for (int i = 0; i < 3; i++)
        {
            PlaceHolder plHldr = e.Row.FindControl("pHldr") as PlaceHolder;
            CheckBox cbx = new CheckBox();
            plHldr.Controls.Add(cbx);//Here I get the exception
        }
    }
