    private DataTable GetDTFromDGV(DataGridView dgv)
    {
        var dt = new DataTable();
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            if (column.Visible)
            {
                dt.Columns.Add();
                if (column.Name != "")
                {
                    dt.Columns[column.Index].ColumnName = column.Name;
                }
            }
        }
        object[] CellValue = new object[dgv.Columns.Count];
        foreach (DataGridViewRow row in dgv.Rows)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                CellValue[i] = row.Cells[i].Value;
            }
            dt.Rows.Add(CellValue);
        }
        return dt;
    }
