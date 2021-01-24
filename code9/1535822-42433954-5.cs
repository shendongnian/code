    List<string> ExcludedColumnsList = new List<string> { "ExcludedColumnName_1", "ExcludedColumnName_2" }; 
    List<int> indexList = dataGridView1.Columns.Cast<DataGridViewColumn>()
                .Where(x => !ExcludedColumnsList.Contains(x.Name))
                .Select(x => x.Index).ToList();
    foreach (DataGridViewRow row in DGVExcel.Rows)
    {
        foreach (int i in indexList)
        { 
            if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value ||
                    String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
            {
                row.Cells[i].Value = 0;
                //DGVExcel.RefreshEdit();
            }
        }
    }
