	// Add columns to "tbl_result" DataTable.
    for (int colCount = 0; colCount < tbl_excel.Columns.Count; colCount++)
    {
        tbl_result.Columns.Add(new DataColumn()
        {
            DataType = tbl_excel.Columns[colCount].DataType,
            ColumnName = tbl_excel.Rows[0][colCount].ToString(),
            AllowDBNull = true
        });
    }
    // Remove row "which is actually the header  in the Excel file".
    tbl_excel.Rows.RemoveAt(0);
    // Set the name of the table.
    tbl_result.TableName = tbl_excel.TableName;
    // Import rows.
    foreach (DataRow row in tbl_excel.Rows)
    {
        tbl_result.Rows.Add(row.ItemArray);
    }
