    private DataSet GetExcelDataSet(string path) {
      string sheetName;
      string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                            "; Jet OLEDB:Engine Type = 5; Extended Properties =\"Excel 8.0;\"";
      ds = new DataSet();
      using (OleDbConnection con = new OleDbConnection(ConnectionString)) {
        using (OleDbCommand cmd = new OleDbCommand()) {
          using (OleDbDataAdapter oda = new OleDbDataAdapter()) {
            cmd.Connection = con;
            con.Open();
            DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            for (int i = 0; i < dtExcelSchema.Rows.Count; i++) {
              sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
              DataTable dt = new DataTable(sheetName);
              cmd.Connection = con;
              cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
              oda.SelectCommand = cmd;
              oda.Fill(dt);
              dt.TableName = sheetName;
              ds.Tables.Add(dt);
            }
          }
        }
      }
      return ds;
    }
