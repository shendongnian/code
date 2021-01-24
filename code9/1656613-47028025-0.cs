    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (!dataGridView1.Rows[e.RowIndex].IsNewRow)) { 
        if (dataGridView1.Columns[e.ColumnIndex].Name == "Remove") {
          DataRowView dataRowView = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
          if (dataRowView != null) {
            //int rowIndex = gridTable.Rows.IndexOf(dataRowView.Row);
            //gridTable.Rows.RemoveAt(rowIndex);
            gridTable.Rows.Remove(dataRowView.Row);
          }
        }
      }
    }
    DataTable gridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      gridTable = GetTable();
      dataGridView1.DataSource = gridTable;
      AddButtonColumnToDGV();
      FillTable(gridTable);
    }
    private void AddButtonColumnToDGV() {
      DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn {
        Name = "Remove",
        Text = "Remove",
        UseColumnTextForButtonValue = true
      };
      dataGridView1.Columns.Add(buttonCol);
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("User Name", typeof(string));
      dt.Columns.Add("First Name", typeof(string));
      dt.Columns.Add("Last Name", typeof(string));
      dt.Columns.Add("Grade", typeof(string));
      return dt;
    }
    private void FillTable(DataTable dt) {
      for (int i = 0; i < 10; i++) {
        dt.Rows.Add("Name" + i, "FName" + i, "LNameR" + i, "GradeR" + i);
      }
    }
