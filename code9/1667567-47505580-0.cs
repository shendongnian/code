    private void btnSearch_Click(object sender, EventArgs e)
    {
       string targetSearch = txtSearch.Text.Trim();
    
       dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
       foreach(DataGridViewRow row in dataGridView1.Rows) {
          if (row.cells[0].value == null)
              continue;
          if(row.cells[0].value.Tostring().Trim().Equals(targetSearch)) {
              row.Selected = true;
              break;
           }
       }
    }
