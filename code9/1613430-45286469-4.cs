	protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e )
	{
		if ( e.Row.RowState.HasFlag( DataControlRowState.Edit ) )
		{
			// Find each input control in the row and set each 
            // Width attribute 
            ((TextBox)e.Row.FindControl( "TextBox1" )).Width = Unit.Pixel(50);
            ((TextBox)e.Row.FindControl( "TextBox2" )).Width = Unit.Pixel(50);
            ...
            ((TextBox)e.Row.FindControl( "TextBoxN" )).Width = Unit.Pixel(50);           
            //  -OR-
            /* Set CssClass attributes in the same manner (but if 
               you're going to do this then you needn't handle this 
               event at all, just do it in the HTML markup and be 
               done with it */
            ((TextBox)e.Row.FindControl( "TextBox1" )).CssClass="EditRowWidth"
		}
	}
