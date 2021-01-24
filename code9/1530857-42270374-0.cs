	private void dgGrid_CellListSelect(object sender, CellEventArgs e)
	{
	    if (e.Cell.Column.Key == "ColumnA")
	    {
	        UltraGridRow selectedItem = ((UltraCombo)e.Cell.EditorControlResolved).SelectedRow;
	        if (selectedItem != null)
	        {
	            UltraCombo cmbValue = new UltraCombo();
			    cmbValue.LimitToList = true;
			    cmbValue.DropDownStyle = UltraComboStyle.DropDownList;
			    cmbValue.DataSource = GetUISender<someBF>().RetrieveData(dataset).dataTable;
			    cmbValue.ValueMember = someDS.someDT.someColumnIDColumn.ColumnName;
			    cmbValue.DisplayMember = someDS.someDT.someColumnDescriptionColumn.ColumnName;
			    cmbValue.BindingContext = someDg.BindingContext;
			    cmbValue.DataBind();
			    e.Cell.Row.Cells["ColumnB"].EditorControl = cmbValue;
			    e.Cell.Row.Cells["ColumnB"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
	        }
	    }
	}
