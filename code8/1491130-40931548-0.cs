    private void gvPrint_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		e.Row.Cells(0).Attributes.Add("class", "text");
    		e.Row.Cells(1).Attributes.Add("class", "text");
    		e.Row.Cells(2).Attributes.Add("class", "text");
    		e.Row.Cells(6).Attributes.Add("class", "text");
    		e.Row.Cells(7).Attributes.Add("class", "text");
    		e.Row.Cells(8).Attributes.Add("class", "text");
    	}
    }
