    for (int i = 0; i < dataGridView1.RowCount; i++) //compare data
      {
        var R = dataGridView1.Rows[i];
        var V = R.Cells[0].Value.ToString() + R.Cells[1].Value.ToString().ToUpper();
        var DupRows = dataGridView1.Rows.Cast<DataGridViewRow>().Skip(i + 1).
                        Where(r => r.Cells[0].Value.ToString() + r.Cells[1].Value.ToString().ToUpper() == V);
        R.Cells[2].Value = (int)R.Cells[2].Value + DupRows.Sum(r => (int)r.Cells[2].Value);
        foreach (var DupRow in DupRows)
          DupRow.Tag = "Del";
      }
      for (int i = 0; i < dataGridView1.RowCount; i++)
      {
        var R = dataGridView1.Rows[i];
        if (R.Tag?.ToString() == "Del")
        {
          dataGridView1.Rows.Remove(R);
          i--;
        }
      }
