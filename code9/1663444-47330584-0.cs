    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
