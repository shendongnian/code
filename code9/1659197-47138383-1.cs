    for (int i = dataGridView1.RowCount - 1; i > 0; i--)
    {
        for (int j = dataGridView1.RowCount - 2; j >= 0; j--)
        {
            if (dataGridView1.Rows[i].Cells[1].Value == dataGridView1.Rows[j].Cells[0].Value)
            {
                int miktar_alici = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                int miktar_satici = Convert.ToInt32(dataGridView1.Rows[j].Cells[2].Value);
                if (miktar_alici == miktar_satici)
                {
                    dataGridView1.Rows[j].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value;
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows[i].Index);
                }
            }
        }
    }
