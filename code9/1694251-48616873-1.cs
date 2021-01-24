    private DataSet GetDSFromExcel() {
      DataSet ds = new DataSet();
      try {
        OpenFileDialog openFileDialog = new OpenFileDialog {
          Filter = "Excel Files| *.xls; *xlsx"
        };
        openFileDialog.ShowDialog();
        if (!string.IsNullOrEmpty(openFileDialog.FileName)) {
          using (OleDbConnection OleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + openFileDialog.FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'")) {
            OleDbcon.Open();
            DataTable WorkbookSheetInfo = OleDbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            String sheetName;
            DataTable dt;
            OleDbDataAdapter oleAdapt;
            for (int i = 0; i < WorkbookSheetInfo.Rows.Count; i++) {
              if ((WorkbookSheetInfo.Rows[i]["Table_Name"].ToString().EndsWith("$'")) ||
                  (WorkbookSheetInfo.Rows[i]["Table_Name"].ToString().EndsWith("$"))) {
                sheetName = WorkbookSheetInfo.Rows[i]["Table_Name"].ToString();
                dt = new DataTable(sheetName.Replace("'", "").Replace("$", ""));
                oleAdapt = new OleDbDataAdapter("Select * from [" + sheetName + "]", OleDbcon);
                oleAdapt.Fill(dt);
                ds.Tables.Add(dt);
              }
            }
          }
        }
      }
      catch (Exception e) {
        MessageBox.Show("ReadExcelIntoDS_Error" + e.ToString());
      }
      return ds;
    }
