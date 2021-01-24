    List<DataGridViewRow> L = new List<DataGridViewRow>();
    for (int i = 1; i < dataGridView1.RowCount; i++) //compare data
    {
      var Row = dataGridView1.Rows[i];
      string abc = Row.Cells[1].Value.ToString() + Row.Cells[2].Value.ToString().ToUpper();
      for (int j = 0; j < i; j++)
      {
        var Row2 = dataGridView1.Rows[j];
        string def = Row2.Cells[1].Value.ToString() + Row2.Cells[2].Value.ToString().ToUpper();
        if (abc == def)
        {
          Row.Cells[5].Value = Row.Cells[5].Value + Row2.Cells[5].Value;
          L.Add(Row2);
        }
      }
    }
    for(int i=0; i<L.Count; i++)
      dataGridView1.Rows.Remove(L[i]);
