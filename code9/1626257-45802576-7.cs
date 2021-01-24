    this.dgwList.Rows(0).Visible == false
    Datatable dtMyTable = new Datatable();
    Datatable dtMyTable2 = new Datatable();
    dtMyTable = ds.tables(0);
    for (ir = 0; ir <= this.dtMyTable.Rows.Count - 1; ir++) {
    	datagridviewRow dr = this.dtMyTable.Rows(ir);
    	if (dr("Brand") == BrandString) {
    		dtMyTable2.ImportRow(dtMyTable.Item(I).Row);
    	}
    }
    private void AddSelectedRowToSelection()
    {
    	// only if a row is selected
    	if (this.dgwList.SelectedRows.Count > 0) {
    		// add this row
    		dtMyTable2.ImportRow(dtMyTable.Item(this.dgwList.SelectedRows(0).Index).Row);
    	}
    }
    this.dgwList.datasource = dtMyTable2;
