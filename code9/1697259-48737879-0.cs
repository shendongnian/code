    string DefaultDirectory = @"D:\Test\ExcelFiles\";
    string[] ExcelFilePaths;
    DataTable BindingSourceDataTable = new DataTable();
    BindingSource GridBindingSource = new BindingSource();
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      BindingSourceDataTable = GetDataFromExcel();
      GridBindingSource.DataSource = BindingSourceDataTable;
      dataGridView1.DataSource = GridBindingSource;
    }
    public DataTable GetDataFromExcel() {
      ExcelFilePaths = Directory.GetFiles(DefaultDirectory, "*.xlsx", SearchOption.AllDirectories);
      DataTable mergedTables = new DataTable();
      string FilePath;
      for (int i = 0; i < ExcelFilePaths.Length; i++) {
        FilePath = ExcelFilePaths[i];
        DataTable tempTable = ImportExcel(FilePath);
        if (tempTable != null) {  // <- ignore workbook files missing the worksheet named 'Sheet1'
          if (i < ExcelFilePaths.Length - 1) { // <- if its the last worksheet do not add the extra row 
            tempTable.Rows.Add();
          }
          mergedTables.Merge(tempTable);
        }
      }
      return mergedTables;
    }
    public DataTable ImportExcel(string FilePath) {
      string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
      using (OleDbConnection Conn = new OleDbConnection(ConnStr)) {
        try {
          DataTable dt = new DataTable();
          OleDbDataAdapter DA = new OleDbDataAdapter("select * from [Sheet1$]", Conn);
          DA.Fill(dt);
          return dt;
        }
        catch (Exception e) {
          // ignore workbook files missing the worksheet named 'Sheet1'
          //MessageBox.Show("No worksheet named 'Sheet1' - Error: " + e.Message);
          return null;
        }
      }
    }
    private void tbFirstName_TextChanged(object sender, EventArgs e) {
      GridBindingSource.Filter = GetFilterStringFromTextBoxes();
    }
    private void tbLastName_TextChanged(object sender, EventArgs e) {
      GridBindingSource.Filter = GetFilterStringFromTextBoxes();
    }
    private string GetFilterStringFromTextBoxes() {
      return string.Format("Customer_Firstname LIKE '%{0}%' and Customer_Lastname LIKE '%{1}%' ", tbFirstName.Text, tbLastName.Text);
    }
  
