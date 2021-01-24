    System.Data.DataTable dt = new System.Data.DataTable();
    public Form2() {
      InitializeComponent();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
      //List<Product> list = ((DataParameter)e.Argument).ProductList;
      System.Data.DataTable list = ((DataParameter)e.Argument).ProductList;
      string filename = ((DataParameter)e.Argument).FileName;
      Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
      Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
      Worksheet ws = (Worksheet)excel.ActiveSheet;
      excel.Visible = false;
      int index = 1;
      //int process = list.Count;
      int process = list.Rows.Count;
      //Add Column
      ws.Cells[1, 1] = "Item Number";
      ws.Cells[1, 2] = "Model";
      ws.Cells[1, 3] = "Manufacturer";
      ws.Cells[1, 4] = "Category";
      ws.Cells[1, 5] = "Subcategory";
       foreach (DataRow dr in list.Rows) {
        if (!backgroundWorker.CancellationPending) {
          backgroundWorker.ReportProgress(index++ * 100 / process);
          ws.Cells[index, 1] = dr.ItemArray[1].ToString();
          ws.Cells[index, 2] = dr.ItemArray[2].ToString();
          ws.Cells[index, 3] = dr.ItemArray[3].ToString();
          ws.Cells[index, 4] = dr.ItemArray[4].ToString();
          ws.Cells[index, 5] = dr.ItemArray[5].ToString();
        }
      }
      //Save file
      ws.SaveAs(filename, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
      excel.Quit();
    }
    struct DataParameter {
      public System.Data.DataTable ProductList;
      public string FileName { get; set; }
    }
    DataParameter _inputParameter;
    private void Form2_Load(object sender, EventArgs e) {
      string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Test\Test3.accdb";
      using (OleDbConnection olcon = new OleDbConnection(ConnectionString)) {
        using (OleDbDataAdapter adapter = new OleDbDataAdapter()) {
          string command = "SELECT * FROM [Products]";
          //cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
          OleDbCommand cmd = new OleDbCommand(command, olcon);
          //Fill Gridview with Data from Access
          try {
            dt.Clear();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            productBindingSource.DataSource = dt;
            dataGridView1.DataSource = productBindingSource;
          }
          catch (Exception ex) {
            MessageBox.Show(ex.ToString());
          }
          finally {
            olcon.Close();
            var totalWidth = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.None);
          }
        }
      }
    }
     private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
      progressBar.Value = e.ProgressPercentage;
      lblStatus.Text = string.Format("Processing...{0}", e.ProgressPercentage);
      progressBar.Update();
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      if (e.Error == null) {
        Thread.Sleep(100);
        lblStatus.Text = "Your data has been successfully exported.";
      }
    }
    private void btnExport_Click(object sender, EventArgs e) {
      if (backgroundWorker.IsBusy)
        return;
      using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls" }) {
        if (sfd.ShowDialog() == DialogResult.OK) {
          _inputParameter.FileName = sfd.FileName;
          //_inputParameter.ProductList = GetProductsList2();
          _inputParameter.ProductList = (System.Data.DataTable)productBindingSource.DataSource;
          progressBar.Minimum = 0;
          progressBar.Value = 0;
          backgroundWorker.RunWorkerAsync(_inputParameter);
        }
      }
    }
