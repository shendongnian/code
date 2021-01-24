      ws.Activate();
      foreach (DataTable dt in ds.Tables)
      {
                // Add column headers from the datatable 
                for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                {
                    ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                }
                // add data rows 
                for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                {  // hey I did not invent this line of code, I found it somewhere on CodeProject. 
                    // It works to add the whole row at once 
                    ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
                }
      ...
