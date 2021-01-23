     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["checkBoxColumn"].Selected)
                {
                    var clientItem = dataGridView1.Rows[e.RowIndex].Cells["SirName"].Value.ToString();
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (item.Cells["SirName"].Value.ToString() != clientItem)
                        {
                            item.Cells["SirName"].ReadOnly = true;
                            item.Cells["SirName"].Style.BackColor = Color.Green;
                        }
    
                    }
                }
               
            }
