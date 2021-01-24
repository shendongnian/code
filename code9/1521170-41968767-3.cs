    protected void gvApplicants_RowDataBound( object sender, GridViewRowEventArgs e )
	{
		if ( e.Row.RowType == DataControlRowType.DataRow )
		{
			GridView gv = (GridView)sender;
			CheckBox cb = (CheckBox) e.Row.FindControl( "selectedMail" );
            String cbid = String.Format( "cb{0}", gv.PageIndex * gv.PageSize + e.Row.RowIndex );
			cb.Attributes["data-unique-id"] = cbid;
            cb.Checked = ViewState[ cbid ]; 
		}
	}
