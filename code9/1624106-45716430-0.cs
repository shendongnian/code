            DataSetTableAdapters.Table1TableAdapter table1TableAdapter = new DataSetTableAdapters.Table1TableAdapter ();
            table1TableAdapter.FillByKey(dataset.Table1,key);
            DataSetTableAdapters.Table2TableAdapter table2TableAdapter = new DataSetTableAdapters.Table2TableAdapter();
            table2TableAdapter.Fill(dataset.Table2);
            DataSetTableAdapters.Table3TableAdapter table3TableAdapter = new DataSetTableAdapters.Table3TableAdapter();
            table3TableAdapter.Fill(dataset.Table3);
            return dataset.Table1.FindBykey(key);
