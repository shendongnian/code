    if ((e.ColumnIndex == 5 || e.ColumnIndex == 6) && e.RowIndex != -1)
    {
        var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        if (cellValue == null || cellValue == DBNull.Value 
         || String.IsNullOrWhiteSpace(cellValue.ToString()))
        {
            MessageBox.Show("Please enter  value");
        }
    }
