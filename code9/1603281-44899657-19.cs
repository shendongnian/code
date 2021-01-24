    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      FillGrid();
    }
    private void FillGrid() {
      dataGridView1.Rows.Add("Cell00Data", "Cell01Data");
      dataGridView1.Rows.Add("Cell10Data", "Cell11Data");
      dataGridView1.Rows.Add("Cell20Data", "Cell21Data");
      dataGridView1.Rows.Add("Cell30Data", "Cell31Data");
    }
    private void btnAdd_Click(object sender, EventArgs e) {
      Form2 f2 = new Form2(dataGridView1);
      f2.ShowDialog();
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      if ((e.RowIndex >= 0) && (!dataGridView1.Rows[e.RowIndex].IsNewRow) ) {
        if (e.ColumnIndex >= 0) {
          if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit") {
            Form2 f2 = new Form2(dataGridView1, e.RowIndex);
            f2.ShowDialog();
          }
        }
      }
    }
