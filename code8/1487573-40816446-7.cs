    private void button1_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in dataGridView1.Rows)
      {
        DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[2];
        if (cell.Value != null)
        {
          cell.Value = cell.FalseValue;
        }
        else
        {
          //cell.Value = cell.TrueValue; // <-- Does not work here when cell.Value is null
          cell.Value = true;
        }
      }
    }
