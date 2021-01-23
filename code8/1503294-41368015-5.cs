    protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e )
	{
		if ( e.Row.RowType == DataControlRowType.DataRow )
		{
			if ( e.Row.RowState.HasFlag( DataControlRowState.Edit ) )
			{
				DataRowView drv = (DataRowView) e.Row.DataItem;
				DropDownList ddl = (DropDownList) e.Row.FindControl( "DropDownList1" );
				ddl.SelectedValue = ((int) drv[ "ID" ]).ToString();
			}
		}
	}
