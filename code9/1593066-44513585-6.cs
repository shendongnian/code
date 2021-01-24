    private void AddAgeColumn() {
      try {
        dataGridView1.Columns.Add("Age", "Age");
        DateTime curBD;
        int curAge;
        foreach (DataGridViewRow dgvr in dataGridView1.Rows) {
          if (!dgvr.IsNewRow) {
            curBD = (DateTime)dgvr.Cells["DOB"].Value;
            curAge = getAge(curBD);
            dgvr.Cells["Age"].Value = curAge;
          }
        }
      }
      catch (Exception e) {
        MessageBox.Show("Error: " + e.Message);
      }
    }
