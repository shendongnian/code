        protected void btnSomeButton_Click( object sender, EventArgs e )
	    {
          if( Gridview1.SelectedDataKey != null)
          {
             String FieldC = (String) GridView1.SelectedDataKey.Values[ "C" ];
             String FieldD = (String) GridView1.SelectedDataKey.Values[ "D" ];
          }
	    }
