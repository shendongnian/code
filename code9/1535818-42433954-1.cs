    int colindex = DGVExcel.Columns["SpecificColumnName"].Index;
    foreach (var row in DGVExcel.Rows)
    {
        if (row.Cells[colindex].Value == null || row.Cells[colindex].Value == DBNull.Value ||
                String.IsNullOrWhiteSpace(row.Cells[colindex].Value.ToString()))
        {
            row.Cells[colindex].Value = 0;
            //DGVExcel.RefreshEdit();
        }
    }
