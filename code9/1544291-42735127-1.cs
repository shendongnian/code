    // The DataGridView SelectionMode must be set  'FullRowSelect' for this to work! 
    private void button1_Click(object sender, EventArgs e) {
      if (dataGridView1.SelectedRows.Count > 0) {
        int firstRowIndex = dataGridView1.SelectedRows.Count - 1;
        string cell = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        string cell2 = dataGridView1.SelectedRows[firstRowIndex].Cells[0].Value.ToString();
        MessageBox.Show("Last selected row at cell[0] value: " + cell + " First Selected row at cell[0] value: " + cell2);
      }
    }
