    protected void GridGaranties_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    	   DataRowView rowView = (DataRowView)e.Row.DataItem;
    	   e.Row.Attributes.Add("idGarantie", (int)rowView["idGarantie"].ToString());
    	}
    }
