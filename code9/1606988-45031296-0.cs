    // Add the column names
    var index = 0;
    foreach(var column in dataGridView1.Columns)
    {
        worksheet.Cells[0, index] = column.HeaderText;
        index++;
    }
    //Loop through each row and read value from each column. 
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
    {
        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        {
            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            cellColumnIndex++;
        }
        cellColumnIndex = 1;
        cellRowIndex++;
    }
