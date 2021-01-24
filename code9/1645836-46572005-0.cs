    foreach(DataGridViewRow row in dataGridView1.Rows)
    {
        foreach(DataGridViewCell cell in row.Cells)
        {
            if(string.IsNullOrEmpty(cell.Value as string))
               {
               //cell is empty
                }
                else
                 {
                   //cell is not empty
                }
        }
    }
