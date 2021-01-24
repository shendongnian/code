    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
               {
                   MessageBox.Show("Test if works"); //it works
               }
        }
