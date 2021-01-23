	private void DataGridCell_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			DataGridCell cl = (DataGridCell)sender;
			//Get the Cell's parent row
			//using System.Windows.Media; for VisaualTreeHelper 
			var DataGridRowParent = VisualTreeHelper.GetParent(cl);
			while (DataGridRowParent != null && DataGridRowParent.GetType() != typeof(DataGridRow))
			{
				DataGridRowParent = VisualTreeHelper.GetParent(DataGridRowParent);
			}
			//Get the Row's parent DataGrid
			var DataGridParent = VisualTreeHelper.GetParent(DataGridRowParent);
			while (DataGridParent != null && DataGridParent.GetType() != typeof(DataGrid))
			{
				DataGridParent = VisualTreeHelper.GetParent(DataGridParent);
			}
			DataGrid dp = DataGridParent as DataGrid;
			//Get the CurrentCell value of DataGrid
			DataGridCellInfo cli = dp.CurrentCell;
			var CellContent = cli.Column.GetCellContent(cli.Item);
			if (CellContent != null)
			{
				//Get DataGridCell of DataGridCellInfo
				DataGridCell dgc = (DataGridCell)CellContent.Parent;
				if (dgc.IsEnabled == false)
				{
					//If the key pressed is Enter or Tab allow
					if (e.Key == Key.Enter || e.Key == Key.Tab)
					{
						e.Handled = false;
						return;
					}
					//If any other key is pressed don't allow.
					e.Handled = true;
					return;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}
