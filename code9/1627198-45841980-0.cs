    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string value = (e.Row.FindControl("lblStatusv") as Label).Text;
        int intValue = int.Parse(value);
        if (intValue == 1)
        {
            e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
            e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
        }
    }
