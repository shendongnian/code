    DataTable allData;
    DataTable comboTable;
    public Form1() {
      InitializeComponent();
    }
    //-------------------------------------------------------------------------
    private void Form1_Load(object sender, EventArgs e) {
      SetDGVColumns();
      allData = GetAllData();
      dataGridView1.DataSource = allData;
    }
    private DataTable GetAllData() {
      DataTable data = new DataTable();
      data.Columns.Add("Set Point Name", typeof(string));
      data.Columns.Add("Description", typeof(string));
      data.Columns.Add("Set Point Type", typeof(string));  // <-- NOTE: this is a string- not a combo box
      data.Rows.Add("nai_m2_no2", "Description 0", "Set Point Type 4");
      data.Rows.Add("nao_enth_no3", "Description 1", "Set Point Type 13");
      data.Rows.Add("nai_m2_no4", "Description 2", "Set Point Type 4");
      data.Rows.Add("nai_m2_no5", "Description 3", "Set Point Type 11");
      data.Rows.Add("nai_m2_no6", "Description 4", "Set Point Type 3");
      data.Rows.Add("nai_m2_no7", "Description 5", "Set Point Type 2");
      return data;
    }
    //-------------------------------------------------------------------------
    private void SetDGVColumns() {
      AddTextCol("Set Point Name");
      AddTextCol("Description");
      dataGridView1.Columns.Add(GetComboColumn()); // <-- THIS DataGridView Column needs to be a combo box column
    }
    //-------------------------------------------------------------------------
    private DataGridViewComboBoxColumn GetComboColumn() {
      comboTable = new DataTable();
      comboTable.Columns.Add("ID", typeof(int));
      comboTable.Columns.Add("Set Point Type", typeof(string));
      for (int i = 0; i < 15; i++) {
        comboTable.Rows.Add(i, "Set Point Type " + i);
      }
      // we now have a data table to use as a data source for the DataGridViewComboBoxColumn
      // make a DataGridViewComboBoxColumn and set it properties
      DataGridViewComboBoxColumn typeCol = new DataGridViewComboBoxColumn();
      typeCol.Width = 150;
      typeCol.DataPropertyName = "Set Point Type";  //<-- needs to match the DataTable column name you want to display - in this case 'Set Point Type'
      typeCol.HeaderText = "Set Point Type";
      typeCol.ValueMember = "Set Point Type";
      typeCol.DisplayMember = "Set Point Type";
      typeCol.Name = "Set Point Type";
      typeCol.DataSource = comboTable;
      return typeCol;
    }
        
    //-------------------------------------------------------------------------
    private void AddTextCol(string colInfo) {
      DataGridViewTextBoxColumn TextCol = new DataGridViewTextBoxColumn();
      TextCol.DataPropertyName = colInfo;
      TextCol.HeaderText = colInfo;
      TextCol.Name = colInfo;
      dataGridView1.Columns.Add(TextCol);
    }
    
