            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                    {
                        file = file + dataGridView2.Rows[i].Cells[j].Value.ToString();
                    }
                }
