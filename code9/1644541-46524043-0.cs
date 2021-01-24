      private void CompareData()
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                for (int j = 0; j < dataGridView3.RowCount - 1; j++)
                {
                    if(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()) >= Convert.ToDouble(dataGridView3.Rows[j].Cells[1].Value.ToString()))
                    {
                       //handle
                    }
                }
            }
            
        }
