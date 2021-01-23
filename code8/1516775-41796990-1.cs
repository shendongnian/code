    DataTable dgvData;
    DataTable cbData;
    public Form1() {
      InitializeComponent();
      dgvData = GetDVGData();
      cbData = GetCBData(dgvData);
      dataGridView1.DataSource = dgvData;
      this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      comboBox1.DisplayMember = "Filter";
      comboBox1.ValueMember = "Filter";
      comboBox1.DataSource = cbData;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
    }
    private DataTable GetCBData(DataTable inDT) {
      DataTable dt = new DataTable();
      dt.Columns.Add("Filter", typeof(string));
      dt.Rows.Add("Remove Filter");
      foreach (DataRow dr in inDT.Rows) {
        dt.Rows.Add(dr.ItemArray[1].ToString());
      }
      return dt;
    }
    
    private DataTable GetDVGData() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Number");
      dt.Columns.Add("Name");
      dt.Columns.Add("Address");
      dt.Rows.Add("1", "John", "Texas");
      dt.Rows.Add("2", "Mary", "Florida");
      dt.Rows.Add("3", "Tom", "New York");
      dt.Rows.Add("4", "Marvin", "Moon");
      dt.Rows.Add("5", "Jason", "Holland");
      dt.Rows.Add("6", "Teddy", "New York");
      return dt;
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      var dataView = ((DataTable)dataGridView1.DataSource).DefaultView;
      if (comboBox1.Text == "Remove Filter") {
        dataView.RowFilter = string.Empty;
      }
      else {
        dataView.RowFilter = $"Name = '{comboBox1.Text}'";
      }
    }
