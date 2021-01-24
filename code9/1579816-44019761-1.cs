    protected void GridUserMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		if (String.IsNullOrWhiteSpace(e.Row.Cells[0].Text))
    		{
    			e.Row.BackColor = System.Drawing.Color.Red;
    		}
    		else
    		{
    			e.Row.BackColor = System.Drawing.Color.White;
    		}
    	}
    }
