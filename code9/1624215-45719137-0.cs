        public System.Data.DataSet AsDataSet(bool convertOADateTime)
		{
			if (!_isValid) return null;
			DataSet dataset = new DataSet();
			for (int ind = 0; ind < _workbook.Sheets.Count; ind++)
			{
				DataTable table = new DataTable(_workbook.Sheets[ind].Name);
    //table filling code snipped
				if (table.Rows.Count > 0)
					dataset.Tables.Add(table);
                table.EndLoadData();
			}
            dataset.AcceptChanges();
		    Helpers.FixDataTypes(dataset);
			return dataset;
		}
