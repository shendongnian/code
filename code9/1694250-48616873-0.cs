    DataSet AllDataTables;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      AllDataTables = GetDSFromExcel();
      foreach (DataTable dt in AllDataTables.Tables) {
        tabControl1.TabPages.Add(GetTabPageWithGrid(dt));
      }
      cb_KPI.DataSource = SetKPI_ValuesForComboBox(AllDataTables.Tables[tabControl1.SelectedIndex]);
    }
