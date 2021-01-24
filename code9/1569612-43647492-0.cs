    private void btnDelete_Click(object sender, EventArgs e) {
      try {
        int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
        int trueRowIndex = dataGridView1.SelectedCells[0].RowIndex;
        //MessageBox.Show("currentRowIndex " + currentRowIndex + " true row index: " + trueRowIndex);
        if (currentRowIndex != trueRowIndex) {
          MessageBox.Show("Row Is New Row");
        }
        else {
          MessageBox.Show("Row Is not New Row");
          dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
          //new SqlCommand("DELETE FROM IncomingVisitorList WHERE Counter = " + counter, SqlConnection).ExecuteNonQuery();
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
