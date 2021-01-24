    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		Label lblA01 = (Label)e.Row.FindControl("lblA01");
    		Label lblA02 = (Label)e.Row.FindControl("lblA02");
    		string val = DataBinder.Eval(e.Row.DataItem, "product").ToString();
    		string[] splittedData = val.Split(';');
    		if (splittedData.Length > 0)
    			lblA01.Text = splittedData[0];
                if (splittedData.Length > 1)
    			lblA01.Text = splittedData[1];
    		}
    	}
    }
