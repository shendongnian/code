    for (int i = 0; i < dataGridView1.RowCount; i++) //compare data
      {
        var R = dataGridView1.Rows[i];
        var V = R.Cells[1].Value.ToString() + R.Cells[2].Value.ToString().ToUpper();
        var DupRows = dataGridView1.Rows.Cast<DataGridViewRow>().Skip(i + 1).
                        Where(r => r.Cells[1].Value.ToString() + r.Cells[2].Value.ToString().ToUpper() == V);
        R.Cells[1].Value = DupRows.Sum(r => (int)r.Cells[5].Value);
        foreach (var DupRow in DupRows)
          dataGridView1.Rows.Remove(DupRow);
      }
