    for (int a = 0; a < dataGridView1.Rows.Count -1 ; a++) {
      for (int b = 0; b < dataGridView1.Columns.Count; b++) {
        if (dataGridView1.Rows[a].Cells[b].Value != null) {
          if (dataGridView1.Rows[a].Cells[b].Value.ToString() != "") {
            textBox1.Text += dataGridView1.Rows[a].Cells[b].Value.ToString() + ",";
          } else {
           // MessageBox.Show("String is empty: ");
          }
        } else {
          //MessageBox.Show("DGV Cell Value is null: ");
        }
      }
      textBox1.Text += Environment.NewLine;
    }
