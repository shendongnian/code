    int sheetIndex = 0;
    DataSet ds = new DataSet();
    public Form1() {
      InitializeComponent();
    }
    private void btnImport_Click(object sender, EventArgs e) {
      var frmDialog = new System.Windows.Forms.OpenFileDialog();
      if (frmDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        String constr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", frmDialog.FileName);
        OleDbConnection myConnection = new OleDbConnection(constr);
        myConnection.Open();
        DataTable spreadSheetData = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = "";
        DataTable dt;
        OleDbCommand onlineConnection;
        OleDbDataAdapter theDataAdapter;
        // fill the "DataSet" each table in the set is a worksheet in the Excel file
        foreach (DataRow dr in spreadSheetData.Rows) {
          sheetName = dr["TABLE_NAME"].ToString();
          sheetName = sheetName.Replace("'", "");
          if (sheetName.EndsWith("$")) {
            onlineConnection = new OleDbCommand("SELECT * FROM [" + sheetName + "]", myConnection);
            theDataAdapter = new OleDbDataAdapter(onlineConnection);
            dt = new DataTable();
            dt.TableName = sheetName;
            theDataAdapter.Fill(dt);
            ds.Tables.Add(dt);
          }
        }
        myConnection.Close();
        scheduleGridView.DataSource = ds.Tables[0];
        setLabel();
      }
    }
    private void setLabel() {
      label1.Text = "Showing worksheet " + sheetIndex + " Named: " + ds.Tables[sheetIndex].TableName + " out of a total of " + ds.Tables.Count + " worksheets";
    }
    private void btnNextSheet_Click(object sender, EventArgs e) {
      if (sheetIndex == ds.Tables.Count - 1)
        sheetIndex = 0;
      else
        sheetIndex++;
      scheduleGridView.DataSource = ds.Tables[sheetIndex];
      setLabel();
    }
