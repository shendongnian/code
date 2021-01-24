     void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow )
        {
    		
    		// set rowspan for the first row of group
            if (Convert.ToInt32(e.Row.Cells[3]) == 1)
            {
    			var rowSpan = Convert.ToString(e.Row.Cells[4]);
                e.Row.Cells[0].Attributes.Add("rowspan", rowSpan);
    			e.Row.Cells[1].Attributes.Add("rowspan", rowSpan);
            }
            else
            {
                e.Row.Cells[0].Visible = false;
    			e.Row.Cells[1].Visible = false;
            }
        }
    }
