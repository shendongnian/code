    DataTable gridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      gridTable = getTable();
      FillGrid(gridTable);
      dataGridView1.DataSource = gridTable;
    }
    private DataTable getTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(string));
      dt.Columns.Add("Value1", typeof(int));
      dt.Columns.Add("Value2", typeof(int));
      dt.Columns.Add(GetFormulaColumn());
      return dt;
    }
    private DataColumn GetFormulaColumn() {
      DataColumn dc = new DataColumn("Result", typeof(int));
      dc.Expression = "Value1 * Value2";
      return dc;
    }
    private void FillGrid(DataTable dt) {
      for (int i = 0; i < 10; i++) {
        dt.Rows.Add("ID" + i, i, i + 3);
      }
    }
