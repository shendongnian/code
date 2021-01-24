    private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MainViewModel mvm = this.DataContext as MainViewModel;
			if ( !mvm.Close() )
				e.Cancel = true;
			else
			{
				....
			}
		}
