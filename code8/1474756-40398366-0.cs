       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                // must selected row first
                if (dataGridView1.SelectedRows.Count == 0)
                    return;
    
                // not support multiple rows select
                if(dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor == Color.Red)
                {
                    if (MessageBox.Show("Check-out?",
                                      "Message de confirmation",
                                      MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {  // non
    
                        MessageBox.Show("Opération éffectuée");
                    }
                }        
            }
