     private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < dataGridView2.Rows.Count -1; x++)
            {
                int m = Convert.ToInt32(dataGridView2.Rows[x].Cells[2].Value);
                if (dataGridView2.Rows[x].Selected)
                {
                    if (m == 1)
                    {
                        MessageBox.Show("Code 1");
                    }
                    if (m == 2)
                    {
                        MessageBox.Show("Code 2");
                    }
                   
                }
          
            }
        }
