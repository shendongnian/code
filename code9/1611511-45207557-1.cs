    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!(dataGridView1.Columns[i] is DataGridViewComboBoxColumn))
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }
        }
    }
