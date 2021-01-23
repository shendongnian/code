    DataTable table1;
    DataTable table2;
    public Form1() {
      InitializeComponent();
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      table1 = GetTable("table1");
      table2 = GetTable("table2");
      FillTable(table1);
      dataGridView1.DataSource = table1;
      dataGridView2.DataSource = table2;
    }
 
    private void button1_Click(object sender, EventArgs e) {
      if (dataGridView1.SelectedRows.Count > 0) {
        foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
          DataRowView dr = (DataRowView)row.DataBoundItem;
          table2.Rows.Add(dr.Row.ItemArray[0], dr.Row.ItemArray[1], dr.Row.ItemArray[2]);
        }
        dataGridView2.Refresh();
      }
    }
    private DataTable GetTable(string name) {
      DataTable table = new DataTable(name);
      table.Columns.Add("col1");
      table.Columns.Add("col2");
      table.Columns.Add("col3");
      return table;
    }
    private void FillTable(DataTable table) {
      for (int i = 0; i < 10; i++) {
        table.Rows.Add("R" + i + "C0", "R" + i + "C1", "R" + i + "C2");
      }
    }
