    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        if (dgv.Columns[e.ColumnIndex].Name.Equals("edit"))
        {
             string status = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
             if (status == "1") 
             {        
                  dgv.Rows[e.RowIndex].Cells["edit"].Value = Properties.Resources.edit_disable;
             }
        }
    }
