    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        {
            DataGridViewCell c = dataGridView1.Rows[i].Cells[j];
            if (c.Value != null)
            {
                listBox1.Items.Add(c.Value.ToString());
            }
        }                
    }
