    for (int i = dataGridView1.RowCount - 2; i >= 0; i--)
    {
        for (int j = 0; j < dataGridView2.RowCount -1; j++)
        {
            string grid2 = dataGridView2.Rows[j].Cells[0].Value.ToString();
            string grid1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (grid1 == grid2)
            {
                dataGridView1.Rows.RemoveAt(i);
                break;
            }
        }
    }
