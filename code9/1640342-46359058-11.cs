    string s1 = "Thomas";
    string s2 = "10000003";
    bool found = false;
    if (dataGridView1 != null) {
      foreach(DataGridViewRow item in dataGridView1.Rows) {
        if (item.Cells[0].Value != null && item.Cells[0].Value.ToString() == s1) {
          found = true;
          break; //stop iteration here since it's already found
        }
      }
      if (!found) {
        string newline = s1 + "," + s2;
        string[] values = newline.Split(',');
        this.dataGridView1.Rows.Add(values);
      } 
      else
        MessageBox.Show("Name already exists in the database");
    }
