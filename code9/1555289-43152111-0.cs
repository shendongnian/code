    private void button1_Click(object sender, EventArgs e) {
      DataGridViewColumn sortCol = dataGridView1.Columns[0];
      if (dataGridView1.SortOrder == SortOrder.None) {
        dataGridView1.Sort(sortCol, ListSortDirection.Ascending);
      } else {
        if (dataGridView1.SortOrder == SortOrder.Ascending) {
          dataGridView1.Sort(sortCol, ListSortDirection.Descending);
        } else {
          dataGridView1.Sort(sortCol, ListSortDirection.Ascending);
        }
      }
    }
