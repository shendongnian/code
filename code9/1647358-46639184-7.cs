    for (int i = 0; i < dataGridView1.RowCount - 1; i++) //compare data
    {
        var Row = dataGridView1.Rows[i];
        string abc = Row.Cells[0].Value.ToString() + Row.Cells[1].Value.ToString().ToUpper();
        for (int j = i+1; j < dataGridView1.RowCount; j++)
        {
          var Row2 = dataGridView1.Rows[j];
          string def = Row2.Cells[0].Value.ToString() + Row2.Cells[1].Value.ToString().ToUpper();
          if (abc == def)
          {
            Row.Cells[2].Value = (int)Row.Cells[2].Value + (int)Row2.Cells[2].Value;
            dataGridView1.Rows.Remove(Row2);
            j--;
          }
        }
    }
