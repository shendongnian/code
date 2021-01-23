        DataTable dtRecords = new DataTable();
        foreach (GridColumn col in grdShippedOrders.Columns)
        {
            DataColumn colString = new DataColumn(col.UniqueName);
            dtRecords.Columns.Add(colString);
        
        }
        foreach (GridDataItem row in grdShippedOrders.Items) // loops through each rows in RadGrid
        {
            DataRow dr = dtRecords.NewRow();
            foreach (GridColumn col in grdShippedOrders.Columns) //loops through each column in RadGrid
                   dr[col.UniqueName] = row[col.UniqueName].Text;
            dtRecords.Rows.Add(dr);
        }
        return dtRecords; 
