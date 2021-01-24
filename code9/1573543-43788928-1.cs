    String searchValue = "3600";
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        int parsedRowCellValue;
        int parsedSearchValue;
        if(int.TryParse(row.Cells[2].Value.ToString(), parsedRowCellValue) && int.TryParse(searchValue, parsedSearchValue))
        {
           if (parsedRowCellValue >= parsedSearchValue)
           { 
               row.DefaultCellStyle.BackColor = Color.Red;
           }
        }
    }
