    private void button2_Click(object sender, EventArgs e) {
      //dataGridView1.Columns.Clear(); <-- clears headers
      //dataGridView1.Rows.Clear(); <-- will crash if data is bound
      //dataGridView1.DataSource = null; <-- removes headers
      dt.Clear();  // <-- Clears data and leaves headers, removes data from table!
    }
    private void button3_Click(object sender, EventArgs e) {
      dt = masterTable.Copy();  // <-- Get a new table if it was cleared
      dataGridView1.DataSource = dt;
    }
  
