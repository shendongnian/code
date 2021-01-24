	protected void gvApplicants_PageIndexChanging( object sender, GridViewPageEventArgs e )
	{
		GridView gv = (GridView) sender;
		foreach( GridViewRow gvr in gv.Rows){
			CheckBox cb = (CheckBox) gvr.FindControl( "selectedMail" );
			String cbid = String.Format( "cb{0}", gv.PageIndex * gv.PageSize + gvr.RowIndex );
			ViewState[ cbid ] = cb.Checked;
		}
	}
