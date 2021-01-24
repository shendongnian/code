    List<string> ExcludedColumnsList = new List<string> { "ExcludedColumnName_1", "ExcludedColumnName_2" };           
    foreach (DataGridViewRow row in DGVExcel.Rows)
    {
        for (int i = 0; i < row.Cells.Count; i++)
        {
            if (!ExcludedColumnsList.Contains(DGVExcel.Columns[i].Name))
            {
                if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value ||
                        String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
                {
                    row.Cells[i].Value = 0;
                    //DGVExcel.RefreshEdit();
                }
            }
        }
    }
