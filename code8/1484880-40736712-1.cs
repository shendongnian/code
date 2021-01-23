		CustomDataSet dsInvoice = new CustomDataSet();
		DataTable tblInvoice = rSelect.ResultSet;
		tblInvoice.TableName = "tblInvoice"; // The TableName which you used while creating the DataTable in DataSet.
		dsInvoice.Merge(tblInvoice);
		
		
