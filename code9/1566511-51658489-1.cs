    			dgMain.QueryRowHeight += dataGrid_QueryRowHeight;
    		private void dataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
		{
			if (dgMain != null &&
				!dgMain.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowResizingOptions, out autoHeight)) return;
			e.Height = autoHeight;
			e.Handled = true;
		}
