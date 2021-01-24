				if ( ListBox1.Items.Contains( ComboBox1.SelectedItem ) )
				{
				    debugMsg( "duplicate", "" );
				}
				else
				{
				    ListBox1.Items.Add( ComboBox1.SelectedItem );
				}
