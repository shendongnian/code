    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["IsChecked"].Selected)
                    {
                        var clientItem = dataGridView1.Rows[e.RowIndex].Cells["clientid"].Value.ToString();
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            if (item.Cells["clientid"].Value.ToString() != clientItem)
                            {
                                item.Cells["clientid"].ReadOnly = true;
                                item.Cells["clientid"].Style.BackColor = Color.Green;
                            }
        
                        }
                    }
                   
                }
