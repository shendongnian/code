    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
            if (cb.Checked == true)
            {
                TableRow row = e.Row;
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                row.RenderControl(htw);
                string rowContents = sw.ToString();
            }
        }
    }
