    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string UnitaText = e.Row.Cells[3].Text;
            ViewState["OrigData"] = UnitaText;
            if (UnitaText.ToString().Length >= 25)
            {
                UnitaText = UnitaText.Substring(0, 25) + "...";
                //20 is the length of your string, you can change it to whatever length you want.
                e.Row.Cells[3].Text = UnitaText;
                e.Row.Cells[3].ToolTip = ViewState["OrigData"].ToString();
            }
        }
    }
