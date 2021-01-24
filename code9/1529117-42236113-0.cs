    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.") {
        MessageBox.Show("ComboBox item does not match at Row:" + e.RowIndex + " Column:" + e.ColumnIndex);
        e.ThrowException = false;
      }
    }
