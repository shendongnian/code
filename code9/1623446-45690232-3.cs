    int count = 1;
    
    dataGridView3.Rows[0].Cells[1].Value = "1.1";
    
    for (int i = 1; i <= dataGridView3.RowCount - 1; i++)
    {
        if (dataGridView3.Rows[i].Cells[2].Value == dataGridView3.Rows[i - 1].Cells[2].Value 
    && dataGridView3.Rows[i].Cells[3].Value == dataGridView3.Rows[i - 1].Cells[3].Value)
        {
            count++;
        }
        else
        {
            count = 1;
        }
        dataGridView3.Rows[i].Cells["Wbs"].Value = "1." + count.ToString();
    }
