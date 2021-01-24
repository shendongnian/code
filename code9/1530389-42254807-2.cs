    private void SetTextBoxColumnLength(int index, int length) {
      if ( (dataGridView1.Columns.Count > index) && (length > 0) ) {
        DataGridViewTextBoxColumn targetColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns[index];
        targetColumn.MaxInputLength = length;
      }
    }
